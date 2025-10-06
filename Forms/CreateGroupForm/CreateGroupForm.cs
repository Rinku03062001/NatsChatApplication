using ChatAppNats.Models;
using ChatAppNats.Services;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ChatAppNats
{
    public partial class CreateGroupForm : Form
    {
        private readonly string _currentUser;
        private readonly ChatService _chatService;
        private readonly string _connectionString = @"server=RINKU-LAPPY\SQLEXPRESS; Database=ChatAppDB; TrustServerCertificate=True; Trusted_Connection=True";


        private List<string> allUsers = new List<string>();
        private HashSet<string> selectedUsers = new HashSet<string>();

        // Event to notify when a new group is created
        public event Action GroupCreated;

        public CreateGroupForm(string currentUser, ChatService chatService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _chatService = chatService;
            allUsers = new List<string>();
            //LoadUsers(allUsers);
        }

        private void CreateGroupForm_Load(object sender, EventArgs e)
        {
            allUsers = GetAllUsers();
            LoadUsers(allUsers);

            // Subscribe to ItemCheck for Checkedlistbox
            clbUsers.ItemCheck += clbUsers_ItemCheck;
        }


        private void LoadUsers(List<string> users)
        {
            clbUsers.Items.Clear();
            //var users = GetAllUsers();
            foreach (var user in users)
            {
                clbUsers.Items.Add(user);
                if (selectedUsers.Contains(user))
                {
                    clbUsers.SetItemChecked(clbUsers.Items.IndexOf(user), true);
                }
            }
        }



        // Fetch all users from database
        private List<string> GetAllUsers()
        {
            var users = new List<string>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "select UserName from Users ";
                // where UserName != @currentUser
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@currentUser", _currentUser);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(reader["UserName"].ToString());
                        }
                    }
                }
            }

            return users;
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text.Trim();
            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Enter Group Name! ");
                return;
            }

            //var selectedUsers = clbUsers.CheckedItems.Cast<string>().ToList();

            for (int i = 0; i < clbUsers.Items.Count; i++)
            {
                if (clbUsers.GetItemChecked(i))
                {
                    selectedUsers.Add(clbUsers.Items[i].ToString());
                }
            }

            if (selectedUsers.Count == 0)
            {
                MessageBox.Show("Select at least one member");
                return;
            }

            int groupId = CreateGroupInDb(groupName, _currentUser);

            foreach (var user in selectedUsers)
            {
                AddUserToGroup(groupId, user);
                SendGroupNotification(user, groupName);
            }

            MessageBox.Show("Group created successfully");

            // Notify chatform to reload groups
            GroupCreated?.Invoke();
            this.Close();
        }


        // Insert group into Groups table
        private int CreateGroupInDb(string groupName, string createdBy)
        {
            int groupId;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "Insert into Groups (GroupName, CreatedBy, CreateDate) output inserted.GroupId values (@GroupName, @CreatedBy, @CreateDate)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@GroupName", groupName);
                    cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                    cmd.Parameters.AddWithValue("@CreateDate", DateTime.UtcNow);
                    groupId = (int)cmd.ExecuteScalar();
                }
            }
            return groupId;
        }



        // Add user to groupMembers table
        private void AddUserToGroup(int groupId, string userName)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "insert into GroupMembers (GroupId, UserName) values (@GroupId,@UserName)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        // Send notification to user
        private async void SendGroupNotification(string userName, string groupName)
        {
            string message = $"You are added to '{groupName}' group.";
            await _chatService.PublishMessageAsync(userName, message);
        }


        public List<string> GetUserGroups(string userName)
        {
            var groups = new List<string>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"select g.GroupName
                                 from Groups g
                                 Inner Join GroupMembers gm 
                                 on g.GroupId = gm.GroupId
                                 where gm.UserName = @userName";

                using (SqlCommand cmd = new SqlCommand(@query, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groups.Add(reader["GroupName"].ToString());
                        }
                    }
                }
            }
            return groups;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbUsers.Items.Count; i++)
            {
                if (clbUsers.GetItemChecked(i) == true)
                {
                    selectedUsers.Add(clbUsers.Items[i].ToString());
                }
            }
            string keyword = txtSearchUser.Text.Trim().ToLower();

            var filtered = allUsers
                .Where(u => u.ToLower().Contains(keyword))
                .ToList();

            LoadUsers(filtered);
        }

        private void clbUsers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string? user = clbUsers.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                selectedUsers.Add(user);
            }
            else
            {
                selectedUsers.Remove(user);
            }

            UpdateSelectedUsersListBox();
        }



        private void UpdateSelectedUsersListBox()
        {
            lstSelectedUsers.Items.Clear();
            foreach (var user in selectedUsers)
            {
                lstSelectedUsers.Items.Add(user);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
