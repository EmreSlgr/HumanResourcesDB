using PdfSharp.Fonts;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HumanResourcesDB
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            GlobalFontSettings.FontResolver = new CustomFontResolver();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    DialogResult result = loginForm.ShowDialog();

                    if (result != DialogResult.OK)
                    {
                        // Kullanıcı login ekranını kapattıysa (çarpıdan)
                        break;
                    }

                    Form userForm = null;

                    if (loginForm.LoggedInRoleId == 1)
                    {
                        userForm = new AdminForm(
                            loginForm.LoggedInUserId,
                            loginForm.LoggedInEmployeeId,
                            loginForm.LoggedInUsername,
                            loginForm.LoggedInRoleId
                        );
                    }
                    else if (loginForm.LoggedInRoleId == 2)
                    {
                        userForm = new HRForm(
                            new EmployeeDataAccess(),  // güvenli ve basit
                            loginForm.LoggedInUserId,
                            loginForm.LoggedInEmployeeId,
                            loginForm.LoggedInUsername
                        );
                    }
                    else if (loginForm.LoggedInRoleId == 3)
                    {
                        userForm = new EmployeeForm(
                            loginForm.LoggedInUserId,
                            loginForm.LoggedInEmployeeId,
                            loginForm.LoggedInUsername
                        );
                    }

                    if (userForm != null)
                    {
                        Application.Run(userForm);
                        // form kapatılınca while döngüsüne geri dönülerek login ekranı tekrar gösterilir
                    }
                }
            }
        }
    }
}



