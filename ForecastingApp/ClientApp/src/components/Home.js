import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;
  constructor(props) {
    super(props);
    this.state = {
      countries: [], cities: [],
      weather: {
        coord: {
          lon: 0,
          lat: 0
        },
        dt: 0,
        wind: {
          speed: 0,
          deg: 0,
          gust: 0
        },
        clouds: {
          all: 0
        },
        main: {
          temp: 0,
          feels_like: 0,
          temp_min: 0,
          temp_max: 0,
          pressure: 0,
          humidity: 0
        },
        celcius: {
          temp: 0,
          feels_like: 0,
          temp_min: 0,
          temp_max: 0,
          pressure: 0,
          humidity: 0
        },
        weather: [
          {
            id: 0,
            main: '',
            description: "haze",
            icon: "50d"
          }
        ]
      }
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleCityChange = this.handleCityChange.bind(this);
  }
  componentDidMount() {
    this.fetchCountries();
  }
  async handleChange(e) {
    var countrycode = e.target.value;
    const response = await fetch('weatherforecast/cities/' + countrycode);
    const data = await response.json();
    this.setState({ cities: data });
  }
  async handleCityChange(e) {
    var city = e.target.value;
    const response = await fetch('weatherforecast/forecast/' + city);
    const data = await response.json();
    const time = new Date((data.dt) * 1000).toUTCString();
    this.setState({ weather: data, time: time });
  }

  render() {
    return (
      <div>
        <h1>Weather Forecast</h1>
        <p>Welcome to weather forecast demo application. Please select city to check the weather</p>
        <div className="container">
          <div className="row">
            <div className="form-group col-6">
              <label>Country</label>
              <select className="form-control" id="optCountry" onChange={this.handleChange}>
                <option value="">select country</option>
                {
                  this.state.countries.map(country => (
                    <option key={country.code} value={country.code}>{country.name}</option>
                  ))
                }
              </select>
            </div>
            <div className="form-group col-6">
              <label>Cities</label>
              <select className="form-control" id="optCity" onChange={this.handleCityChange}>
                <option value="">select city</option>
                {
                  this.state.cities.map(city => (
                    <option key={city.name} value={city.name}>{city.name}</option>
                  ))
                }
              </select>
            </div>
          </div>

        </div>
        <div className="container">
          <h3>Location</h3>
          <div className="row">
            <div className="form-group col-4">
              <label>City</label>
              <label className="form-control">{this.state.weather.name}</label>
            </div>
            <div className="form-group col-4">
              <label>Lon/Lat</label>
              <label className="form-control">{this.state.weather.coord.lon},{this.state.weather.coord.lat}</label>
            </div>
            <div className="form-group col-4">
              <label>Time</label>
              <label className="form-control">{this.state.time}</label>
            </div>
          </div>
          <h3>Wind</h3>
          <div className="row">
            <div className="form-group col-4">
              <label>Speed</label>
              <label className="form-control">{this.state.weather.wind.speed}</label>
            </div>
            <div className="form-group col-4">
              <label>Deg</label>
              <label className="form-control">{this.state.weather.wind.deg}</label>
            </div>
            <div className="form-group col-4">
              <label>Gust</label>
              <label className="form-control">{this.state.weather.wind.gust}</label>
            </div>
          </div>
          <h3>Additional</h3>
          <div className="row">
            <div className="form-group col-4">
              <label>Visibility</label>
              <label className="form-control">{this.state.weather.visibility}</label>
            </div>
            <div className="form-group col-4">
              <label>Sky Conditions(cloudiness)</label>
              <label className="form-control">{this.state.weather.clouds.all}%</label>
            </div>
            <div className="form-group col-4">
              <label>Wheater Description</label>
              <label className="form-control">{this.state.weather.weather[0].description}</label>
            </div>
          </div>
          <h3>Temperature</h3>
          <div className="row">
            <div className="form-group col-3">
              <label>Actual(F/C)</label>
              <label className="form-control">{this.state.weather.main.temp}/{this.state.weather.celcius.temp}</label>
            </div>
            <div className="form-group col-3">
              <label>Feel like(F/C)</label>
              <label className="form-control">{this.state.weather.main.feels_like}/{this.state.weather.celcius.feels_like}</label>
            </div>
            <div className="form-group col-3">
              <label>Temp min(F/C)</label>
              <label className="form-control">{this.state.weather.main.temp_min}/{this.state.weather.celcius.temp_min}</label>
            </div>
            <div className="form-group col-3">
              <label>Temp max(F/C)</label>
              <label className="form-control">{this.state.weather.main.temp_max}/{this.state.weather.celcius.temp_max}</label>
            </div>
          </div>
          <div className="row">
            <div className="form-group col-3">
              <label>Pressure</label>
              <label className="form-control">{this.state.weather.main.pressure}</label>
            </div>
            <div className="form-group col-3">
              <label>Humidity</label>
              <label className="form-control">{this.state.weather.main.humidity}</label>
            </div>
          </div>
        </div>
      </div>
    );
  }

  async fetchCountries() {
    const response = await fetch('weatherforecast/countries');
    const data = await response.json();
    this.setState({ countries: data });
  }

}
