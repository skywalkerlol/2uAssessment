import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';
class SignalRWebsocketService {
    
    constructor() {
        //var transport = TransportType.WebSockets;
       // let logger = new ConsoleLogger(LogLevel.Information);

        // create Connection
        //this._connection = new HubConnection('https://localhost:44353/signalrpath',
        //    {  });
        this._connection = new HubConnectionBuilder()
            .withUrl("https://localhost:44353/signalrpath")
            .configureLogging(LogLevel.Information)
            .build();
        this._connection.start().catch(err => console.error(err, 'red'));

        //this._connection.on('RefreshInvoiceList',() => {
        //    //FetchInvoices.Refresh call
        //    console.info("received refresh message from server");
        //});
    }

    registerRefreshList(refresh) {
        // get nre chat message from the server
        this._connection.on('RefreshInvoiceList', () => {
            console.info("received refresh message from server");
            refresh();
        });
    }


}
const WebsocketService = new SignalRWebsocketService();

    export default WebsocketService;