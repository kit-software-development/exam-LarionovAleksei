﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace GameClient.GUI.Login
{
    public partial class LoginForm : Form, ITextOwnerControl
    {

        public event EventHandler<LoginFormEventArgs> Login;
        public event EventHandler<LoginFormEventArgs> Signup;
        public LoginForm()
        { 
            InitializeComponent();

            loginSubform.Show();
            loginSubform.ChangeToRegisterUi += OnChangeToRegisterUi;

            registrationSubform.Hide();
            registrationSubform.ChangeToLoginUi += OnChangeToLoginUi;

            this.AcceptButton = loginSubform.btnLogin;

            loginSubform.Login += (o, e) => Login?.Invoke(this, e);
            registrationSubform.Signup += (o, e) => Signup?.Invoke(this, e);
            // TODO: uniform font
        }

        public bool FieldsFilled {
            get => current_ui_login ? loginSubform.FieldsFilled : registrationSubform.FieldsFilled;
        }


        public void Reset()
        {
            loginSubform.Reset();
            registrationSubform.Reset();
        }

        public void SetFont(Font font)
        {
            // TODO: uniform font
        }

        private void OnChangeToLoginUi(object sender, EventArgs e)
        {
            registrationSubform.Hide();
            loginSubform.Reset();
            loginSubform.Show();
            current_ui_login = true;
            this.Size = new Size(this.Size.Width, 180);
            this.Text = "Login";
        }

        private void OnChangeToRegisterUi(object sender, EventArgs e)
        {
            loginSubform.Hide();
            registrationSubform.Reset();
            registrationSubform.Show();
            current_ui_login = false;
            this.Size = new Size(this.Size.Width, 215);
            this.Text = "Register User";
        }

        private bool current_ui_login;

    }

    public class LoginFormEventArgs : EventArgs
    {
        public string Username { get; set; }
        public string PasswordText { get; set; }

        public LoginFormEventArgs(string user, string pass_text)
        {
            Username = user;
            PasswordText = pass_text;
        }
    }
}
