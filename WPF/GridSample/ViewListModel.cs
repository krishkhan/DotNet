using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data;
using System.ComponentModel;

namespace GridSample
{
    public class ViewListModel : INotifyPropertyChanged
    {
        #region Child Window instances
        public AddView addmovieWindow;
        #endregion


        private Movie _movie;
        private IMovieSource _movieSource;
        public ObservableCollection<Movie> Movies { get; set; }

        private Movie _selectedRow;

        public Movie SelectedRow
        {
            get
            {
                return _selectedRow;
            }
            set
            {
                _selectedRow = value;
                OnPropertyChanged("SelectedRow");
            }
        }

        public bool IsEditEnabled
        {
            get{return _isEditEnabled;}
            
            set
            {
                _isEditEnabled = value;
                OnPropertyChanged("IsEditEnabled");
            }
        }

        public Movie CurrentMovie
        {
            get { return _movie; }
            set { _movie = value; }
        }

        public ViewListModel(IMovieSource movieSource)
        {
            this._movieSource = movieSource;
            _movieSource.MovieDBUpdated += new Action<Movie>(movieDataBaseUpdated);

            //subscribe to Add button click 
            Movies = new ObservableCollection<Movie>();

        }

        public ViewListModel()
        {
            Movies = new ObservableCollection<Movie>();

            Movies.Add(new Movie() { Name = "Gabbar Singh", Details = "Pawan kalyan,Teslugu Industry Best,Entertainment" });//for debugging
            //Edit = EditPermission.EnableEdit;//can be removed
            IsEditEnabled = false;
        }

        public Action<Movie> movieDataBaseUpdated { get; set; }

        #region Button actions
        public void LaunchAddItem()
        {
            addmovieWindow = new AddView();
            CurrentMovie = new Movie();
            addmovieWindow.Show();
        }

        public void AddItem()
        {
            if (null != addmovieWindow)
            {
                //logic to increment the sl number
                CurrentMovie.SLNo = Movies.Count + 1;
                Movies.Add(CurrentMovie);
                addmovieWindow.Close();
            }
        }

        public void EditItem()
        {
            IsEditEnabled = true;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void UpdateItem()
        {
            Movie temp = SelectedRow;

        }

        #endregion


        #region INotifyPropertyChanged Members

        private bool _isEditEnabled;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

       
        #endregion
    }
}
    
