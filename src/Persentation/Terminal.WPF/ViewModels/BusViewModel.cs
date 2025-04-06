using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Application.Dtos;
using Terminal.Application.Services;
using Terminal.WPF.Commands;

namespace Terminal.WPF.ViewModels;

public class BusViewModel : BaseViewModel
{
    private readonly BusService busService;

    public BusViewModel()
    {
        busService = App.AppHost.Services.GetRequiredService<BusService>();
        LoadList();
    }

    private void LoadList()
    {
        Buses = new ObservableCollection<BusDto>(busService.GetAll());
    }
    #region Fields

    private ObservableCollection<BusDto> buses = new();
    public ObservableCollection<BusDto> Buses
    {
        get { return buses; }
        set { buses = value; }
    }

    private BusDto selectedItem;

    public BusDto SelectedItem
    {
        get { return selectedItem; }
        set { selectedItem = value; }
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

    #region Commands
    public RelayCommand AddCommand => new RelayCommand(execute => Add());
    private void Add()
    {
        try
        {
            busService.Add(new BusDto
            {
                Id = Id,
                Title = Title,
                Capacity = Capacity,
                Code = Code,
                Model = model,
                Rate = Rate
            });
        }
        catch (Exception)
        {

            throw;
        }

    }
    #endregion
}
