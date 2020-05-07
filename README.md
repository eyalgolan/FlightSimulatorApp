# FlightSimulatorApp
Advanced Programming 2 course, Flight Simulator App

Created by: Yair Hanimov and Eyal Golan

## Preview
A flight simulator desktop application program that interacts with a dedicated server.
We build the application using the MVVM software architectural pattern.
The program features a convenient user interface for operating a small aircraft.
The GUI contains four main components: A map components, a dashboard, a joystick and a connection section.

The user can connect to a server using the connect section, and fly the plane using the joystick. 
The plane moves on the map according to the data recieved from the server.
The dasboard data is also displayed according to the data recieved from the server. 

![flightSimulator](images/flightSimulator.JPG)

## Program explanation
### MVVM software architectural pattern
The program contains four main components: A map components, a dashboard, a joystick and a connection section.
Each component has it's own View - View-Model - Model:
Each components has it's own model, view-model and view. The model implements an interface, that inherits from the INotifyPropertyChanged interface.

In the Dashboard and Map components, the models update the view-model when a property has changed, as the view-model updates the view - about changes that arrived from the server.

For example, the LatitudeError property in the dashboard's model:
```
//Property holding errors regarding the plane's latitude
        public String LatitudeError
        {
            get
            {
                return this.latitudeError;
            }
            set
            {
                this.latitudeError = value;
                NotifyPropertyChanged("LatitudeError");
            }
        }
```
In the view model we updated the matching property and immediatly updated the view:
```
model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("Vm" + e.PropertyName);
            };
...
//Property responsible for relaying latitude errors
        public String VmLatitudeError
        {
            get
            {
                return this.model.LatitudeError;
            }
        }
```
In the Gear component, the view updates the view-model which then updates the view - about changes the user made to the joystick.
In the connection section, we 
## Error handling
### server status
The application displays the different connection states:

If the application is disconnected from a server:

![Disconnected from server](images/DisconnectedFromServer.JPG)

If there is a timeout from the server:

![Server timeout](images/serverTimeout.JPG)
### validating the data

The application validates the incoming data from the server, and show if any received data from the server is incorrect. The application will not use that data, and will show the last correct information.

![Dashboard when data is all valid](images/DashboardWithAlllValid.JPG)
![Dashboard when some data is not valid](images/DasboardDataError.JPG)

The application also validates the latitude and longtitude infromation that are received from the server, and shows if wrong data was received. Simillarly, it will show the last correct information.

![Map when bad latitude received](images/BadLatitude.JPG)
