# CarMonitoringSystem
<br/>
![Systmem acrchitecture sketch](https://i.imgur.com/kYLL8G4.jpg)
<br/>
<br/>
*The main idea behind the design of the system was to make it scalable and supportable, because over time the amount of cars and companies could increase.
Currently there are four parts of the system StatusesGenerator, ApiGateway, DataStore and StatusesDashboard, which are communication via http requests between each other (if that would be production code I would choose a message queue istead).
Thinking of scalability and convinient usage I decided to use an ApiGateway to receive all of the incoming requests and route them to the appropriate part of the system. 
Keeping in mind that the received data needs to be store and showed ApiGateway sends sttus object to the DataStore, while StatusesDashboard continiously (every 5 sec) requests DataStoreApi to get updates to show them on the FrontEnd. This requests hammering overall is a bad approach as it is overloading the APIs, but it has been chosen to speedup the development.
The right approach is to use SignalR to update car statuses only when the new status arrived and in addition to that use message queue to send two messages at the samme time from the ApiGateway to StatusesDashboard (and instantly update status on the dashboard) and to DataStore for storage (which is less urgent, because we will store it for analycal purposes). In the current implementation statuses are updated every time when they arriving instead of been saved.
<br/>
<br/>
*It would be fairly easy to deploy each part of the solution to the cloud as three separated AppServices and SQL server as service. 
 But generaly there are could other variations with usage of cloud native solutions like  Azure Application Gateway.
 It is also possible to dockerize each component and use Kubernetes.
<br/>
<br/>
*Deployment suppose to be preatty strait forward and in this order.<br/>
	*ApiGateway
	*DataStore
	*StatusesDashboard

