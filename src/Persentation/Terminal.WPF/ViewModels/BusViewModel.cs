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

    private ObservableCollection<BusDto> buses;
    public ObservableCollection<BusDto> Buses
    {
        get { return buses; }
        set { buses = value; NotifyPropertyChanged(); }
    }

    private BusDto selectedItem;

    public BusDto SelectedItem
    {
        get { return selectedItem; }
        set 
        {
            selectedItem = value;
            if (value != null)
            {
                Id = value.Id;
                Title = value.Title;
                Rate = value.Rate;
                Capacity = value.Capacity;
                Code = value.Code;
                Model = value.Model;
            }
            NotifyPropertyChanged();
        }
    }

    private int id;

    public int Id
    {
        get { return id;  }
        set { id = value; NotifyPropertyChanged(nameof(id)); }
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
    public RelayCommand DeleteCommand => new RelayCommand(execute => Delete(),canExecute => SelectedItem != null);
    public RelayCommand UpdateCommand => new RelayCommand(execute => Update());

    private void Update()
    {
        try
        {
            busService.Update(new BusDto
            {
                Id = Id,
                Title = Title,
                Capacity = Capacity,
                Code = Code,
                Model = model,
                Rate = Rate
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
            busService.Delete(Id);
            MessageBox.Show("Deleted Successfully","Success",MessageBoxButton.OK, MessageBoxImage.Information);
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
            busService.Add(new BusDto
            {
                Id = 0,
                Title = Title,
                Capacity = Capacity,
                Code = Code,
                Model = model,
                Rate = Rate
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
