using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Application.Dtos;
using Terminal.Application.Services;

namespace Terminal.WPF.ViewModels;

public class BusViewModel : BaseViewModel
{
    private readonly BusService busService;

    public BusViewModel()
    {
        busService = App.AppHost.Services.GetRequiredService<BusService>();

    }

    #region Fields
    private ObservableCollection<BusDto> buses = new();
    public ObservableCollection<BusDto> Buses
    {
        get { return buses; }
        set { buses = value; }
    }

    private BusDto selectedIndex;

    public BusDto SelectedIndex
    {
        get { return selectedIndex; }
        set { selectedIndex = value; }
    }

    private int id;

    public int Id
    {
        get { return id;  }
        set { id = value; NotifyPropertyChanged(); }
    }

    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; NotifyPropertyChanged(); }
    }

    private int capacity;

    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; NotifyPropertyChanged(); }
    }

    private decimal rate;

    public decimal Rate
    {
        get { return rate; }
        set { rate = value; NotifyPropertyChanged(); }
    }

    private int code;

    public int Code
    {
        get { return code; }
        set { code = value; NotifyPropertyChanged(); }
    }

    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; NotifyPropertyChanged(); }
    }

    #endregion
}
