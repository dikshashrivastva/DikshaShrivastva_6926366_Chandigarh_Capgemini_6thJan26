function checkWeather(){

let city=document.getElementById("cityInput").value;

let weatherData={

"Paris":{temp:"22",condition:"Sunny",icon:"☀"},
"London":{temp:"16",condition:"Rainy",icon:"🌧"},
"Tokyo":{temp:"19",condition:"Cloudy",icon:"☁"},
"Delhi":{temp:"30",condition:"Sunny",icon:"☀"},
"New York":{temp:"18",condition:"Cloudy",icon:"☁"}

};

if(weatherData[city]){

let data=weatherData[city];

document.getElementById("cityName").innerText=city;

document.getElementById("temperature").innerText=data.temp+"°C";

document.getElementById("condition").innerText=data.condition;

document.getElementById("weatherIcon").innerText=data.icon;

document.body.classList.remove("sunny","rainy","cloudy");

if(data.condition==="Sunny"){
document.body.classList.add("sunny");
}

else if(data.condition==="Rainy"){
document.body.classList.add("rainy");
}

else{
document.body.classList.add("cloudy");
}

}

else{

alert("City not in mock data");

}

}