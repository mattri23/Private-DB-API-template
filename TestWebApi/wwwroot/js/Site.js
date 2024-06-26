﻿let GetData = () => {
    fetch('/weatherforecast')
        .then(data => data.json())
        .then(weatherArray => {
            let formattedWeatherArray = weatherArray.map(weather => `ID: ${weather.Id}, Date: ${new Date(weather.Date).toDateString()}, TemperatureC: ${weather.TemperatureC}, TemperatureF: ${weather.TemperatureF}, Summary: ${weather.Summary}`);
            document.getElementById("root").innerHTML = formattedWeatherArray.join('<br>');
        });
}

let GetDataById = () => {
    let id = prompt("Enter Id of the record to fetch");

    fetch(`/weatherforecast/${id}`)
        .then(data => data.json())
        .then(weather => {
            let formattedWeather = `ID: ${weather.id}, Date: ${new Date(weather.date).toDateString()}, TemperatureC: ${weather.temperatureC}, TemperatureF: ${weather.temperatureF}, Summary: ${weather.summary}`;
            console.log(formattedWeather);
        });
}

let PostData = () => {
    let data = {
        AddDays: document.getElementById("DTAddInput").value,
        TemperatureC: document.getElementById("GCelciusInput").value,
        Summary: document.getElementById("SummaryInput").value 
    };

    fetch('/weatherforecast', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
    .then(response => response.json())
    .then(data => {
        console.log('Success:', data);
        //document.getElementById("root").innerHTML = JSON.stringify(data, null, 2);
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}

let PutData = () => {
    let data = {
        Id: document.getElementById("IdInput").value,
        AddDays: document.getElementById("DTAddInput").value,
        TemperatureC: document.getElementById("GCelciusInput").value,
        Summary: document.getElementById("SummaryInput").value 
    };

    fetch(`/weatherforecast/${data.Id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
    .then(response => response.json())
    .then(data => {
        console.log('Success:', data);
        //document.getElementById("root").innerHTML = JSON.stringify(data, null, 2);
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}

let DeleteDataById = () => {
    let id = prompt("Enter Id of the record to delete");

    fetch(`/weatherforecast/${id}`, {
        method: 'DELETE',
    })
    .then(response => response.json())
    .then(data => {
        console.log('Success:', data);
        //document.getElementById("root").innerHTML = JSON.stringify(data, null, 2);
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}


document.addEventListener('DOMContentLoaded', () => {});