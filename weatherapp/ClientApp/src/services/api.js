
 const api = {
    getCities: async (country) => await fetch(`cities?country=${country}`)
                    .then((response) => {
                        if (response.ok) {
                            return response.json();
                        }
                        throw new Error(`${response.status} ${response.statusText}`);
                    }),
    getWeather: async (city) => await fetch(`weather?city=${city}`)
                    .then((response) => {
                        if (response.ok) {
                            return response.json();
                        }
                        throw new Error(`${response.status} ${response.statusText}`);
                    })
                    
  }

  export default api