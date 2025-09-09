namespace ChatAppNats
{
    public static class InputBox
    {
        public static string Show(string prompt, string title)
        {
            Form inputForm = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9),
                Padding = new Padding(20)
            };

            Label lblPrompt = new Label()
            {
                Text = prompt,
                Width = 350,
                Left = 20,
                Top = 20,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(241, 241, 241)
            };

            TextBox txtInput = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 350,
                Height = 35,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(63, 63, 70),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                Padding = new Padding(5)
            };


            Button btnOk = new Button()
            {
                Text = "OK",
                Left = 180,
                Width = 90,
                Top = 100,
                Height = 32,
                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Left = 280,
                Width = 90,
                Top = 100,
                Height = 32,
                DialogResult = DialogResult.Cancel,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(86, 86, 86),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            // Add hover effects
            btnOk.MouseEnter += (sender, e) => { btnOk.BackColor = Color.FromArgb(28, 151, 234); };
            btnOk.MouseLeave += (sender, e) => { btnOk.BackColor = Color.FromArgb(0, 122, 204); };

            btnCancel.MouseEnter += (sender, e) => { btnCancel.BackColor = Color.FromArgb(120, 120, 120); };
            btnCancel.MouseLeave += (sender, e) => { btnCancel.BackColor = Color.FromArgb(86, 86, 86); };



            inputForm.Controls.Add(lblPrompt);
            inputForm.Controls.Add(txtInput);
            inputForm.Controls.Add(btnOk);
            inputForm.Controls.Add(btnCancel);

            inputForm.AcceptButton = btnOk;
            inputForm.CancelButton = btnCancel;

            // Add some animation on load
            inputForm.Load += (sender, e) =>
            {
                inputForm.Opacity = 0;
                System.Windows.Forms.Timer fadeIn = new System.Windows.Forms.Timer();
                fadeIn.Interval = 10;
                fadeIn.Tick += (s, args) =>
                {
                    if (inputForm.Opacity >= 1)
                        fadeIn.Stop();
                    else
                        inputForm.Opacity += 0.05;
                };
                fadeIn.Start();
            };

            // Set focus to textbox
            inputForm.Shown += (sender, e) => txtInput.Focus();


            return inputForm.ShowDialog() == DialogResult.OK ? txtInput.Text : string.Empty;
        }
    }
}
