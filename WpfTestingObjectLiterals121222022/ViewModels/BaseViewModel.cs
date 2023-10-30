using System.ComponentModel;

/*
 * wir wollen keine Abhängungen zwischen View und Viewmodel sondern nur ein Databinding
 * Jede ViewModel-Klasse wir von BaseViewmodel abgeleitet
 * 
 * Reihenfolge:
 * 
 * 1) Window-Konstruktor wird aufgerufen
 * 2) this.Datacontext = _viewModel (hier wird intern auch eine anmeldung der View am Event
 *    der ViewModel-Klasse gemacht)
 * 3) Ein Property, das in der View angezeigt wird wird verändert
 * 4) durch die Implementierung des Set() wird OnPropertyChanged aufgerufen
 * 5) OnPropertyChanged() löst die Delegates am Event aus
 * 6) Die View zeichnet den Teil neu, der mit dem Property verbunden war ({Binding Ergebnis})
 */


namespace MVCWpfRechner.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        // Die View registriert sich beim Start des Windows an diesem Event
        // Wir müssen bei einer Änderung unserer Properties the registrierten Delegates aufrufen
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            // Prüfen, ob sich jemand registriert hat
            if (PropertyChanged != null)
            {
                // Aufruf der Registrierten delegates
                // Parameter:
                // 1) this => Referenz auf das ViewModel Objekt
                // 2) Property Name, des den Wert verändert hat
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
