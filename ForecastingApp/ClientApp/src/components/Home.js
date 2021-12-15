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
          deg: 0
        }
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
          <div className="form-group">
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
          <div className="form-group">
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
        <div className="container">
          <h3>Location</h3>
          <div className="form-group">
            <label>City</label>
            <label className="form-control">{this.state.weather.name }</label>
          </div>
          <div className="form-group">
            <label>Lon/Lat</label>
            <label className="form-control">{this.state.weather.coord.lon},{this.state.weather.coord.lat}</label>
          </div>
          <div className="form-group">
            <label>Time</label>
            <label className="form-control">{this.state.time}</label>
          </div>
          <h3>Wind</h3>
          <div className="form-group">
            <label>Speed</label>
            <label className="form-control">{this.state.weather.wind.speed}</label>
          </div>
          <div className="form-group">
            <label>Deg</label>
            <label className="form-control">{this.state.weather.wind.deg}</label>
          </div>
          <h3>Visibility</h3>
          <div className="form-group">
            <label>Visibility</label>
            <label className="form-control">{this.state.weather.visibility}</label>
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
