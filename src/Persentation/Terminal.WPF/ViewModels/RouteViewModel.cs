using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Terminal.Application.Dtos;
using Terminal.Application.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Terminal.WPF.Commands;

namespace Terminal.WPF.ViewModels;

public class RouteViewModel : BaseViewModel
{
    private readonly RouteService routeService;
    private readonly TripService tripService;
    public RouteViewModel()
    {
        routeService = App.AppHost.Services.GetRequiredService<RouteService>();
        tripService = App.AppHost.Services.GetRequiredService<TripService>();   
        LoadList();
    }

    private void LoadList()
    {
        Routes = new ObservableCollection<RouteDto>(routeService.GetAll());
    }

    #region Fields

    private ObservableCollection<RouteDto>  routes ;

    public ObservableCollection<RouteDto> Routes
    {
        get { return routes; }
        set { routes = value; NotifyPropertyChanged(); }
    }

    private ObservableCollection<TripListDto> tripRoutes;

    public ObservableCollection<TripListDto> TripRoutes
    {
        get { return tripRoutes; }
        set { tripRoutes = value; NotifyPropertyChanged(); }
    }

    private RouteDto selectedItem;

    public RouteDto SelectedItem
    {
        get { return selectedItem; }
        set 
        {
            selectedItem = value;
            if(value != null)
            {
                Id = value.Id;
                Origin = value.Origin;
                Destination = value.Destination;
                BasePrice = value.BasePrice;
                TripRoutes = new ObservableCollection<TripListDto>(tripService.GetByRouteId(value.Id));
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

    private string origin;

    public string Origin
    {
        get { return origin; }
        set { origin = value; NotifyPropertyChanged(); }
    }

    private string destination;

    public string Destination
    {
        get { return destination; }
        set { destination = value; NotifyPropertyChanged(); }
    }

    private decimal basePrice;

    public decimal BasePrice
    {
        get { return basePrice; }
        set { basePrice = value; NotifyPropertyChanged(); }
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
            routeService.Update(new RouteDto
            {
                Id = Id,
                Destination = Destination,
                Origin = Origin,
                BasePrice = BasePrice,
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
            routeService.Remove(Id);
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
            routeService.Add(new RouteDto
            {
                Id = 0,
                BasePrice = BasePrice,
                Destination = Destination,
                Origin = Origin,
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
