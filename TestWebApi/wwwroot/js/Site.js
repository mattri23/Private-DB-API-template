let GetData = () => {
    fetch('/weatherforecast')
        .then(data => data.json())
        .then(text => document.getElementById("root").innerHTML = JSON.stringify(text, null, 2));
}

let postData = () => {
    let data = {
        AddDays: prompt("Enter number of days to add to today's date", 1),
        TemperatureC: prompt("Enter temperature in Celsius", 25),
        Summary: prompt("Enter summary", "Sunny")
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
        document.getElementById("root").innerHTML = JSON.stringify(data, null, 2);
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}


document.addEventListener('DOMContentLoaded', () => {GetData()});