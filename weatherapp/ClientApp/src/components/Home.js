import React, { useEffect, useState } from 'react';
import styled from 'styled-components';
import { colors } from './../constants/colors';
import api from './../services/api';

const StyledContentContainer = styled.div`
font-family: "Roboto";
font-style: normal;
display: flex;
padding-top: 30px;

.input-filters {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  
  .input-style {
    padding: 15px;
    margin: 10px;
    box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
    border-radius: 6px;
    border: 1px solid ${colors.lightGrey}
  }

  .submit-btn-style {
    min-width: 120px;
    margin: 10px;
    padding: 10px;
    box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
    border-radius: 6px;
    border: 1px solid ${colors.lightGrey}
  }

  .submit-btn-style:hover {
    background-color: ${colors.blackhole};
    color: ${colors.white};
    border-radius: 4px;
  }
}

.weather-panel {
  padding: 25px;
  padding-top: 0px;

  .error-message {
    color: ${colors.error};
    padding: 10px;
  }
}


`;

export default function Home() {
  const [country, setCountry] = useState("");
  const [options, setOptions] = useState([]);
  const [error, setError] = useState([]);
  const [city, setCity] = useState("");
  const [weather, setWeather] = useState({});
  
  function handleOnChangeCountry(event) {
   if (event.keyCode === 13) {
    setError("");
      api.getCities(country)
      .then((data) => {
        if (data.length > 0) {
          const result = data.map((item) => (item.city.map((city) => {
            return {"value": city, "label" : city}
          })))
          setOptions(result[0])
        }
        else {
          setError('Error: No city found for this country, please try "Indonesia"/"Brazil"/"England"');
        }
      })
      .catch((error) => {
        setError(`Error: ${error.message}`);
      })
    }
  }

  function HandleSubmitClick() {
    setError("");
      api.getWeather(city)
      .then((data) => {
        if (data.length > 0) {
          setWeather(data[0])
        }
        else {
          setWeather({});
          setError(`Error: No weather data found for ${city}, please try another cities in "Indonesia"`);
        }
      })
      .catch((error) => {
        setWeather({});
        setError(`Error: ${error.message}`);
      })
  }

  return (
      <StyledContentContainer>
        <div className="input-filters">
                    <input className="input-style" onChange={(e) => setCountry(e.target.value)} onKeyDown={(e) => handleOnChangeCountry(e)} placeholder="Insert country, then press enter"></input>
                    <select className="input-style" onChange={(e) => setCity(e.target.value)}>
                      <option value="">Select City</option>
                      {options.length > 0 && 
                            options.map((element) => (
                               <option value={element.value}>{element.label}</option>
                            ))
                      }
                    </select>
                    <button className="submit-btn-style" onClick={HandleSubmitClick}>Submit</button>
        </div>
        <div className='weather-panel'>
          {weather.location && (
              <>
              <p>Location: {weather.location}</p>
              <p>Date/time: {weather.time}</p>
              <p>Pressure: {weather.pressure} Millibar</p>   
              <p>Humidity: {weather.relativeHumidity}</p>
              <p>Sky Conditions: {weather.skyCondition}</p>         
              <p>Temperature: {weather.temperatureC} &#8451; / {weather.temperatureF} &#8457;</p>
              <p>Visibility: {weather.visibility} KM</p>
              <p>Wind: {weather.wind} KPH</p>
              </>
            )
          }
           {error && <p className='error-message'>{error}</p>}
        </div>
         
      </StyledContentContainer>
    );
}
