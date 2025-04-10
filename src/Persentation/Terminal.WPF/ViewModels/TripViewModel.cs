using Microsoft.Extensions.DependencyInjection;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Terminal.Application.Dtos;
using Terminal.Application.Services;
using Terminal.WPF.Commands;

namespace Terminal.WPF.ViewModels;

public class TripViewModel : BaseViewModel
{
    private readonly TripService tripService;
    private readonly RouteService routeService;
    private readonly BusService busService;

    public TripViewModel()
    {
        tripService = App.AppHost.Services.GetRequiredService<TripService>();
        routeService = App.AppHost.Services.GetRequiredService<RouteService>();
        busService = App.AppHost.Services.GetRequiredService<BusService>();
        BusList = new ObservableCollection<BusComboDto>(busService.ComboList());
        RouteList = new ObservableCollection<RouteComboDto>(routeService.ComboList());
        TripDate = DateTime.Now;
        LoadList();
    }

    private void LoadList()
    {
        Trips = new ObservableCollection<TripListDto>(tripService.GetAll());

    }

    #region Fields

    public ObservableCollection<BusComboDto> BusList { get; set; } 
    public ObservableCollection<RouteComboDto> RouteList { get; set; }

    private BusComboDto selectedBusItem;

    public BusComboDto SelectedBusItem
    {
        get { return selectedBusItem; }
        set
        {
            selectedBusItem = value;
            busId = value.Id;
            NotifyPropertyChanged();
        }
    }

    private RouteComboDto selectedRouteItem;

    public RouteComboDto SelectedRouteItem
    {
        get { return selectedRouteItem; }
        set 
        {
            selectedRouteItem = value;
            routeId = value.Id;
            NotifyPropertyChanged();
        }
    }


    private ObservableCollection<TripListDto> trips;
    public ObservableCollection<TripListDto> Trips
    {
        get { return trips; }
        set { trips = value; NotifyPropertyChanged(); }
    }


    private TripListDto selectedItem;

    public TripListDto SelectedItem
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            if (value != null)
            {
                Id = value.Id;
                busId = value.BusId;
                RouteId = value.RouteId;
                TripDate = value.DateTime;
                Code = value.Code;
                SelectedBusItem = BusList.Where(x => x.Id == value.BusId).FirstOrDefault();
                SelectedRouteItem = RouteList.Where(x => x.Id == value.RouteId).FirstOrDefault();
            }
            NotifyPropertyChanged();
        }
    }

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; NotifyPropertyChanged(nameof(id)); }
    }

    private string code;

    public string Code
    {
        get { return code; }
        set { code = value; NotifyPropertyChanged(); }
    }

    private int busId;

    public int BusId
    {
        get { return busId; }
        set 
        {
            busId = value; 
            NotifyPropertyChanged(); 
        }
    }

    private int routeId;

    public int RouteId
    {
        get { return routeId; }
        set { routeId = value; NotifyPropertyChanged(); }
    }

    private DateTime tripDate;

    public DateTime TripDate
    {
        get { return tripDate; }
        set { tripDate = value; NotifyPropertyChanged(); }
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
                BusId = BusId,
                RouteId = RouteId,
                DateTime = TripDate
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
            tripService.Add(new TripDto
            {
                Id = 0,
                Code = "",
                BusId = BusId,
                RouteId = RouteId,
                DateTime = TripDate
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
