using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegistryLab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey myKey = Registry.CurrentUser;
            RegistryKey wKey = myKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", true);
            wKey.SetValue("link", "0");
            wKey.Close();
            MessageBox.Show("Сделано");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey myKey = Registry.CurrentUser;
            RegistryKey wKey = myKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", true);
            wKey.SetValue("link", "1e 00 00 00");
            wKey.Close();
            MessageBox.Show("Возвращего как было");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = myKey.OpenSubKey("SOFTWARE\\Classes\\lnkfile", true);
            wKey.DeleteValue("IsShortcut");
            wKey.Close();
            MessageBox.Show("Удалено");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = myKey.OpenSubKey("SOFTWARE\\Classes\\lnkfile", true);
            wKey.SetValue("IsShortcut","");
            wKey.Close();
            MessageBox.Show("Возвращено как было");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegistryKey myKey = Registry.CurrentUser;
            RegistryKey wKey = myKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies", true); //ВЕТКА
            wKey.CreateSubKey("System"); //СОЗДАЕМ
            RegistryKey restKey = wKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true); //ПОДВЕТКА
            restKey.SetValue("DisableTaskMgr",1); //ПРОПИСЫВЕМ
            restKey.Close(); //ЗАКРЫВАЕМ
            wKey.Close(); //ЗАКРЫВАЕМ
            MessageBox.Show("Отключено");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistryKey myKey = Registry.CurrentUser;
            RegistryKey wKey = myKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies", true);
            RegistryKey restKey = wKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
            restKey.SetValue("DisableTaskMgr", 0);
            restKey.DeleteValue("DisableTaskMgr");
            restKey.Close();
            wKey.DeleteSubKey("System");
            wKey.Close();
            MessageBox.Show("Возвращено как было");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            RegistryKey myKey = Registry.CurrentUser;
            RegistryKey wKey = myKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true); //ВЕТКА
            wKey.SetValue("RestrictRun", 1); //ПРОПИСЫВАЕМ
            wKey.CreateSubKey("RestrictRun"); //СОЗДАЕМ
            RegistryKey restKey = wKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\RestrictRun", true); //ПОДВЕТКА
            restKey.SetValue("NoDriveType", 145); //ПРОПИСЫВАЕМ 
            restKey.SetValue("RestrictRun", 1);
            restKey.SetValue("C:\\Windows\\regedit.exe", Application.ExecutablePath); // ПРОПИСЫВЕМ ПРИЛОЖЕНИЯ
            restKey.SetValue("C:\\Windows\\explorer.exe", Application.ExecutablePath);
            restKey.SetValue("C:\\Windows\\notepad.exe", Application.ExecutablePath);
            restKey.SetValue("C:\\Program Files(x86)\\Microsoft\\Edge\\Application\\msedge.exe", Application.ExecutablePath);
            restKey.SetValue("C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE", Application.ExecutablePath);
            restKey.SetValue("C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE", Application.ExecutablePath);
            restKey.SetValue("C:\\Program Files\\Microsoft Office\\root\\Office16\\POWERPNT.EXE", Application.ExecutablePath);
            restKey.Close(); //ЗАКРЫВАЕМ
            wKey.Close(); //ЗАКРЫВАЕМ
            MessageBox.Show("Отключено");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            RegistryKey myKey = Registry.CurrentUser;
            RegistryKey wKey = myKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);
            wKey.SetValue("RestrictRun", 0);
            wKey.DeleteSubKey("RestrictRun");
            wKey.DeleteValue("RestrictRun");
            wKey.Close();
            MessageBox.Show("Возвращено как было");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            button7.Enabled = true;
        }
    }
}
