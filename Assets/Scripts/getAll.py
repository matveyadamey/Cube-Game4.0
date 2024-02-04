from datetime import datetime
import requests
import tzlocal

tzlocal.get_localzone_name()

gorod = open('C:/Users/matve/Documents/GitHub/Cube-Game4.0/Assets/Scripts/city.txt', 'r')
city = gorod.read()

url = 'https://api.openweathermap.org/data/2.5/weather?q=' + city + '&units=metric&lang=ru&appid=79d1ca96933b0328e1c7e3e7a26cb347'
weather_data = requests.get(url).json()

tz = tzlocal.get_localzone()
chp = weather_data['timezone'] / 3600

hour = str(int(datetime.now(tz).strftime("%H")) + int(chp - 3))

current_weather = str(weather_data['weather'][0]['description'])

if 'облачно' in current_weather:
    current_weather = 3
elif 'пасмурно' in current_weather or 'дождь' in current_weather:
    current_weather = 5
elif 'снег' in current_weather:
    current_weather = 7
elif 'ясно' in current_weather:
    current_weather = 0
elif 'туман' in current_weather:
    current_weather = 1

time = open("C:/Users/matve/Documents/GitHub/Cube-Game4.0/Assets/Scripts/time.txt", "w")
time.write(hour)
time.close()

weather = open('C:/Users/matve/Documents/GitHub/Cube-Game4.0/Assets/Scripts/weather.txt', 'w')
weather.write(str(current_weather))
weather.close()
