using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab2.DataAccess;
using RestSharp;
using Microsoft.Identity.Client.NativeInterop;
using Newtonsoft.Json;

namespace Lab3.WpfApplication.ViewModels
{
    public class TestViewModel : ObservableObject
    {
        public TestViewModel(int initialCounter) : this()
        {
            counter = initialCounter;
            Student = new Student();
        }

        public TestViewModel()
        {
            IncrementCounterCommand = new RelayCommand(IncrementCounter);
            AddCommand = new RelayCommand(AddStudent);
        }

        private int counter;

        public int Counter
        {
            get => counter;
            private set => SetProperty(ref counter, value);
        }

        private Student[] students;

        public Student Student { get; set; }
        public Student[] Students => students;

        public ICommand IncrementCounterCommand { get; }

        public ICommand AddCommand { get; }

        private void IncrementCounter() => Counter++;

        private async void AddStudent()
        {
            var options = new RestClientOptions("https://localhost:7118/")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("api/Student", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(Student);
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
        }

        internal async Task Load()
        {
            var options = new RestClientOptions("https://localhost:7118/")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("api/Student", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            var result = JsonConvert.DeserializeObject<Student[]>(response.Content);

            students = result;
        }
    }
}
