﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace ProjectDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {


            InitializeComponent();
            if (!FileIO.HandleProjectDefaultLocation(SETTINGS.DEFAULT_PATH, SETTINGS.DEFAULT_FOLDER_NAME))
            {
                MessageBox.Show("Failed to set default directory.");
                this.Close();
                return;
            }
            if (FileIO.GetProjectsFromLocation(System.IO.Path.Combine(SETTINGS.DEFAULT_PATH, SETTINGS.DEFAULT_FOLDER_NAME), out List<Project> readProjects))
            {
                if (VM.MyProjects == null)
                {
                    VM.MyProjects = new ObservableCollection<Project>();
                }
                VM.MyProjects.Clear();
                foreach (var project in readProjects)
                {
                    VM.MyProjects.Add(project);
                }
            }
            else
            {
                MessageBox.Show("Failed to get projects from default directory.");
                this.Close();
                return;
            }
        }



        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            VM.SetProject();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_WebLaunch_Click(object sender, RoutedEventArgs e)
        {
            VM.SelectedWebPath.Launch();
        }

        private void Btn_FolderLaunch_Click(object sender, RoutedEventArgs e)
        {
            VM.SelectedFolderPath.Launch();
        }

        private void Btn_SoftwLaunch_Click(object sender, RoutedEventArgs e)
        {
            VM.SelectedSoftwarePath.Launch();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (!VM.SaveProject())
            {
                MessageBox.Show("Failed to save project");
            };
        }

        private void btn_AddFolder_Click(object sender, RoutedEventArgs e)
        {
            VM.AddFolder();
        }

        private void btn_AddWebpage_Click(object sender, RoutedEventArgs e)
        {
            VM.AddWebpath();
        }

        private void btn_AddSoftware_Click(object sender, RoutedEventArgs e)
        {
            VM.AddSoftwarePath();
        }

        private void btn_AddContact_Click(object sender, RoutedEventArgs e)
        {
            VM.AddContact();
        }

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            if (!VM.LoadProject())
            {
                MessageBox.Show("Failed to load project.");
            }
        }
    }
}