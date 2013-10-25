using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSearcher.Annotations;
using DataSearcherSolution.Data;
using DataSearcherSolution.Model;
using DataSearcherSolution.Repository;

namespace DataSearcherSolution
{
    public class SearcherWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        private readonly IPeopleSearchRepository peopleRepo;
        private string firstNameSearchCriteria = string.Empty;
        private string lastNameSearchCriteria = string.Empty;
        #endregion Fields

        #region Properties
        public string FirstNameSearchCriteria
        {
            get { return this.firstNameSearchCriteria; }
            set
            {
                if (value != this.firstNameSearchCriteria)
                {
                    this.firstNameSearchCriteria = value;
                    OnPropertyChanged();
                    UpdatePeople();
                    OnPropertyChanged("People");
                }
            }
        }

        
        public string LastNameSearchCriteria
        {
            get { return this.lastNameSearchCriteria; }
            set
            {
                if (value != this.lastNameSearchCriteria)
                {
                    this.lastNameSearchCriteria = value;
                    OnPropertyChanged();
                    UpdatePeople();
                    OnPropertyChanged("People");
                }
            }
        }

        public ObservableCollection<Person> People { get; set; }
        #endregion Properties

        #region Constructors
        public SearcherWindowViewModel(IPeopleSearchRepository peopleRepo)
        {
            this.peopleRepo = peopleRepo;
            People = new ObservableCollection<Person>(this.peopleRepo.GetAllPeople());
        }

        public SearcherWindowViewModel() : this(new PeopleDatabaseSearcher())
        {    
        }

        #endregion Constructors

        #region Methods
        private void UpdatePeople()
        {
            var result = peopleRepo.GetAllPeople();
            
            var filtered = result.Where(
                        p =>
                            p.FirstName.ToLower().StartsWith(firstNameSearchCriteria.ToLower()) &&
                            p.LastName.ToLower().StartsWith(lastNameSearchCriteria.ToLower()));

            People = new ObservableCollection<Person>(filtered);
        }
        #endregion Methods

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged implementation
    }
}
