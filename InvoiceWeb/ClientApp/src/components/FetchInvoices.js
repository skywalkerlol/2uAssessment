import React, { Component } from 'react';
import WebsocketService from '../services/WebsocketService';

export class FetchInvoices extends Component {
    displayName = FetchInvoices.name

  //TODO move the fetches into its a service. move the url host to config.
     fetchInvoices() {
        fetch('https://localhost:44353/api/Invoice?status=0')
            .then(response => response.json())
            .then(data => {
                this.setState({ invoices: data, loading: false });
            });
    }
     approve(inv) {
        inv.status = 1;//attempt to set to approved
        //put invoice here update state...
        fetch('https://localhost:44353/api/Invoice/' + inv.id, {
            method: 'PUT',
            mode: 'cors',
            body: JSON.stringify(inv),
            headers: { 'Content-Type': 'application/json' }
        }).then(res => {
            console.log(res);

            //todo 
            //refetch here if successful
            this.fetchInvoices();
            //display error if failed

            }).catch(err => {
                console.error(err)
            });
    }
    constructor(props) {
        super(props);
        this.state = { invoices: [], loading: true };
        this.fetchInvoices();
        WebsocketService.registerRefreshList(() => {
            this.fetchInvoices();
        });
    }
     renderInvoices(invoices) {
        var that = this;
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Action</th>
            <th>Invoice Number</th>
            <th>Invoice Total</th>
            <th>Invoice Date</th>
            <th>Due Date</th>
            <th>Vendor Name</th>
            <th>Vendor Address</th>
          </tr>
        </thead>
        <tbody>
                { 
                invoices.map(inv =>
                    <tr key={inv.id}>
                        <td><button onClick={()=> that.approve(inv)}>Approve</button></td>
                <td>{inv.invoice_number}</td>
                <td>{inv.total}</td>
                <td>{inv.invoice_date}</td>
                <td>{inv.due_date}</td>
                <td>{inv.vendor_name}</td>
                <td>{inv.remittance_address}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderInvoices(this.state.invoices);

    return (
      <div>
        <h1>Invoice Approval</h1>
        <p>Please approve the pending Invoices.</p>
        {contents}
      </div>
    );
  }
}
