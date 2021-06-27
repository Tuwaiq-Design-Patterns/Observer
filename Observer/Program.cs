using System;
using System.Collections.Generic;

namespace Observer
{
    interface IObserver
    {
        public void Update(float temp, float humidity, float wind);
    }

    interface ISubject
    {
        public void Subscribe(IObserver o);
        public void Unsubscribe(IObserver o);
        public void Notify();
    }

    class WeatherData : ISubject 
    { 
        private readonly List<IObserver> _observers; 
        private float Temperature { get; set; } 
        private float Humidity { get; set; }
        private float Wind { get; set; }
        
        public WeatherData()
        { 
            _observers = new List<IObserver>();
        }
        
        public void Subscribe(IObserver o) 
        { 
            _observers.Add(o); 
        } 
        
        public void Unsubscribe(IObserver o) 
        { 
            _observers.Remove(o); 
        } 
        
        public void Notify() 
        {
            foreach (var observer in _observers)
            {
                observer.Update(Temperature, Humidity, Wind);
            }
        }

        public void SetMeasurements(float temperature, float humidity, float wind) 
        { 
            Temperature = temperature;
            Humidity = humidity;
            Wind = wind;
            Notify(); 
        }
        
    }
    
    class Forecast : IObserver
    {

        private float _currentTemperature;
        private float _currentHumidity;
        private float _currentWind;
        private float _lastTemperature = 45.4f;
        private float _lastHumidity = 18;
        private float _lastWind = 11;
        private WeatherData _weatherData;

        public Forecast(WeatherData weatherData)
        {
            _weatherData = weatherData;
            _weatherData.Subscribe(this);
        }
        
        public void Update(float temp, float humidity, float wind)
        {
            _currentTemperature = temp;
            _currentHumidity = humidity;
            _currentWind = wind;
            Display();
        }

        private void Display()
        {
            Console.WriteLine("\nWeather Forecast: ");
            if (_currentWind < _lastWind)
            {
                Console.WriteLine("wind is expected to decrease");
            }
            if (_currentTemperature < _lastTemperature)
            {
                Console.WriteLine("temperature is expected to decrease");
            }
            if (_currentHumidity > _lastHumidity)
            {
                Console.WriteLine("humidity is expected to increase");
            }
        }

    }

    class Statistics : IObserver {
        
        private float _maxTemp = 0.0f;
        private float _minTemp = 60;
        private float _tempSum = 0.0f;
        private int _numReadings;
        private WeatherData _weatherData;

        public Statistics(WeatherData weatherData)
        {
            _weatherData = weatherData;
            _weatherData.Subscribe(this);
        }
        
        public void Update(float temp, float humidity, float pressure)
        {
            _tempSum += temp;
            _numReadings++;

            if (temp > _maxTemp)
            {
                _maxTemp = temp;
            }

            if (temp < _minTemp)
            {
                _minTemp = temp;
            }

            Display();
        }

        private void Display()
        {
            Console.WriteLine("\nTemperature statistics: ");
            Console.WriteLine($"Avg temperature: {(_tempSum / _numReadings)}");
            Console.WriteLine($"Max temperature: {_maxTemp}");
            Console.WriteLine($"Min temperature: {_minTemp}");
        }

    }
    
    
    class CurrentWeather : IObserver {
        private float _temperature;
        private float _humidity;
        private float _wind;
        private readonly WeatherData _weatherData;

        public CurrentWeather(WeatherData weatherData)
        {
            _weatherData = weatherData;
            _weatherData.Subscribe(this);
        }

        public void Update(float temp, float humidity, float wind)
        {
            _temperature = temp;
            _humidity = humidity;
            _wind = wind;
            Display();
        }

        private void Display()
        {
            Console.WriteLine("\nCurrent weather: ");
            Console.WriteLine($"temperature: {_temperature} ° \nhumidity {_humidity}% \nwind: {_wind} km/h");
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            CurrentWeather currentDisplay =
                new CurrentWeather(weatherData);
            Statistics statistics = new Statistics(weatherData);
            Forecast forecast = new Forecast(weatherData);

            weatherData.SetMeasurements(37.7f, 6, 13);
            Console.WriteLine("-------------------------------------------");
            weatherData.SetMeasurements(42.5f, 8, 11);
            Console.WriteLine("-------------------------------------------");
            weatherData.SetMeasurements(32.4f, 3, 7);
        }
    }
}