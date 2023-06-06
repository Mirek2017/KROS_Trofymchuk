using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using System.Net.Http;
using System.Text.Json;

namespace Test.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _currentDateTime;
        public string CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                _currentDateTime = value;
                OnPropertyChanged();
            }
        }
        public string CurrentDeviceInfo
        {
            get
            {
                var deviceInfo = new StringBuilder()
                    .AppendLine($"Device: {DeviceInfo.Idiom}")
                    .AppendLine($"Manufacturer: {DeviceInfo.Manufacturer}")
                    .AppendLine($"Platform: {DeviceInfo.Platform}")
                    .AppendLine($"OS Version: {DeviceInfo.VersionString}");                    
                return deviceInfo.ToString();
            }
        }
        public ICommand UpdateTimeCommand { get; }

        public MainViewModel()
        {
            UpdateTimeCommand = new Command(UpdateTime);
            CurrentDateTime = DateTime.Now.ToString("F");
        }
        private void UpdateTime()
        {
            CurrentDateTime = DateTime.Now.ToString("F");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //public class TodoItem
        //{
        //    public int UserId { get; set; }
        //    public int Id { get; set; }
        //    public string Title { get; set; }
        //    public bool Completed { get; set; }
        //}
        //private async Task FetchDataFromApiAsync()
        //{
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
        //    if(response.IsSuccessStatusCode)
        //    {
        //        var json = await response.Content.ReadAsStringAsync();
        //        var todoItem = JsonSerializer.Deserialize<ToggledEventArgs>(json);
        //        //Process the todoItem as needed
        //    }
        //}
    }
}
