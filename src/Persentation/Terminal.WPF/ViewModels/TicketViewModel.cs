using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Terminal.Application.Dtos;
using Terminal.Application.Services;
using Terminal.Domain.Entities;
using Terminal.WPF.Commands;

namespace Terminal.WPF.ViewModels;

public class TicketViewModel : BaseViewModel
{
    private readonly TicketService ticketService;
    private readonly TripService tripService;

    public TicketViewModel()
    {
        this.ticketService = App.AppHost.Services.GetRequiredService<TicketService>();
        this.tripService = App.AppHost.Services.GetRequiredService<TripService>();
        Trips = new ObservableCollection<TripComboDto>(tripService.GetCombo());
        LoadList();
    }

    private void LoadList()
    {
        Tickets = new ObservableCollection<TicketListDto>(ticketService.GetAll());

    }

    #region Fields

    private ObservableCollection<TicketListDto> tickets;        

    public ObservableCollection<TicketListDto> Tickets
    {
        get { return tickets; }
        set { tickets = value; NotifyPropertyChanged(); }
    }

    private TicketListDto selectedItem;

    public TicketListDto SelectedItem
    {
        get { return selectedItem; }
        set { selectedItem = value;  NotifyPropertyChanged(); }
    }


    public ObservableCollection<TripComboDto> Trips{ get; set; }

    private TripComboDto selecteTripItem;

    public TripComboDto SelectedTripItem
    {
        get { return selecteTripItem; }
        set 
        {
            selecteTripItem = value;
            if (value != null)
            {
                TripId = value.Id;
            }
            NotifyPropertyChanged(); 
        }
    }

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; NotifyPropertyChanged(); }
    }

    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; NotifyPropertyChanged(); }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; NotifyPropertyChanged(); }
    }

    private int tripId;

    public int TripId
    {
        get { return tripId; }
        set { tripId = value; NotifyPropertyChanged(); }
    }

    #endregion

    #region Commands
    public RelayCommand AddCommand => new RelayCommand(execute => Add());
    public RelayCommand DeleteCommand => new RelayCommand(execute => Delete());
    public RelayCommand UpdateCommand => new RelayCommand(execute => Update());

    private void Update()
    {
        try
        {
            tripService.Update(new TripDto
            {
                Id = Id,
                Code = "",
            });
            MessageBox.Show("Updated Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }

    private void Delete()
    {
        try
        {
            tripService.Delete(Id);
            MessageBox.Show("Deleted Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void Add()
    {
        try
        {
            ticketService.Add(new TicketDto
            {
                Id = 0,
                FirstName = FirstName,
                LastName = LastName,
                TripId = TripId
            });
            MessageBox.Show("Added Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

    }
    #endregion
}
