using System.Timers;

namespace lab15sem3
{
    public interface IFileSystemObserver
    {
        void OnFileChanged(string filePath);
        void OnFileCreated(string filePath);
        void OnFileDeleted(string filePath);
    }

    public class SimpleFileSystemWatcher
    {
        private readonly string _directoryPath;
        private readonly List<IFileSystemObserver> _observers = new List<IFileSystemObserver>();
        private readonly System.Timers.Timer _timer;
        private HashSet<string> _existingFiles;

        public SimpleFileSystemWatcher(string directoryPath, double interval)
        {
            _directoryPath = directoryPath;
            _timer = new System.Timers.Timer(interval);
            _timer.Elapsed += CheckForChanges;
            _existingFiles = new HashSet<string>(Directory.GetFiles(directoryPath));
            _timer.Start();
        }

        public void Subscribe(IFileSystemObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IFileSystemObserver observer)
        {
            _observers.Remove(observer);
        }

        private void CheckForChanges(object sender, ElapsedEventArgs e)
        {
            var currentFiles = new HashSet<string>(Directory.GetFiles(_directoryPath));
            foreach (var file in currentFiles.Except(_existingFiles))
            {
                NotifyFileCreated(file);
            }

            foreach (var file in _existingFiles.Except(currentFiles))
            {
                NotifyFileDeleted(file);
            }
            _existingFiles = currentFiles;
        }

        private void NotifyFileChanged(string filePath)
        {
            foreach (var observer in _observers)
            {
                observer.OnFileChanged(filePath);
            }
        }

        private void NotifyFileCreated(string filePath)
        {
            foreach (var observer in _observers)
            {
                observer.OnFileCreated(filePath);
            }
        }

        private void NotifyFileDeleted(string filePath)
        {
            foreach (var observer in _observers)
            {
                observer.OnFileDeleted(filePath);
            }
        }
    }
}