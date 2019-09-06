# My Notes

## Story 1 API Back End:
Since the use case is for a simple document, I went with a document db and not a relation database. I used a cosmos db emulator as a server side data store. This is convenient to run locally. You can download from here : https://aka.ms/cosmosdb-emulator

## Story 2 Front End:
Ideally I would have used redux for state management on the front end for a more complicated use case. Since this was a simple Invoice approval page, i tried to keep it simple.

### Run Instructions
1. You need to have .net core 2.1 sdk installed and at least VS2017.
2. Set the InvoiceApi and InvoiceWeb as multiple startup projects in visual Studio. 
3. Install cosmos db emulator. You can download from here : https://aka.ms/cosmosdb-emulator
4. Update following values in InvoiceApp.Data/DocumentDBRepository.cs from the cosmosdb emulator web page
```csharp
private  readonly string Endpoint = "https://localhost:8081";
private  readonly string Key = "primarykey123";
```
5. Update InvoiceWeb\ClientApp\src\components\FetchInvoices.js and replace the 'https://localhost:44353/api/' entries with the invoiceapi url.
6. Post a few requests with body below to the Api. You can access swagger doc at https://localhost:port/swagger. feel free to update values. 
```json
{
    "invoice_number": "inv1246",
    "total": 4.99,
    "currrency": "usd",
    "invoice_date": "2019-09-04T23:53:01.016Z",
    "due_date": "2019-09-04T23:53:01.016Z",
    "vendor_name": "Kroger",
    "remittance_address": "1st Main st Charlotte NC 28277"
}
```
7. Start application from VS
8. Try approving. 
9. Try posting new invoices, it should update the UI automatically since it should be using websockets.
10. You can use the developer console in browser to troubleshoot incase of any issues with web or socket connection. 

# 2uAssessment

The business analyst assigned to your sprint team has presented you with two user stories to complete this sprint. This assessment asks you to complete these story cards to the best of your ability. 

The assessment is more about creating a working solution that meets as many of the acceptance criteria as possible than it is about getting every detail perfect. It is not necessary to complete every acceptance criteria to submit the assessment. Complete what you can and leave "TODO:" comments with appropriate placeholder instructions anywhere you are unable to complete your code. You must turn the assignment by the end of the third day after you are given the assignment.

Fork this repo and push the code to your new forked repo. Submit the forked repo's URL to greg@2ulaundry.com

## User story 1
As a vendor supplying services to 2ULaundry I need to submit invoices via an API in order to receive payment in a timely manner.

### Acceptance criteria
1. The API accepts JSON formatted HTTP POST requests at the route '/Invoice'
The following is a sample Invoice request that will be submitted to the API endpoint.
```javascript
{
  "invoice_number": "12345",
  "total": "199.99",
  "currency": "USD",
  "invoice_date": "2019-08-17",
  "due_date": "2019-09-17",
  "vendor_name": "Acme Cleaners Inc.",
  "remittance_address": "123 ABC St. Charlotte, NC 28209"
}
```

2. The API returns an HTTP 200 Response code and the following message body

```javascript
{
  "message": "invoice submitted successfully"
}
```
3. Store the invoices in a data store of your choice with an additional property and value "status": "pending" 

## User story 2
As a member of the 2ULaundry Accounting Team I need to see a list of invoices that have been submitted by vendors, but have not yet been approved for payment so that I can review and approve them.


### Acceptance criteria
1. Create an interface with react.js that shows a list of unapproved invoices that are submitted via API described in user story #1.
2. Display the following fields for each invoice:"Invoice Number", "Vendor Name", "Vendor Address", "Invoice Total", "Invoice Date", "Due Date"
3. Create a solution that allows the user to select and approve invoices. Once an invoice is "Approved" it should dissappear from the list of available invoices.
4. When the user approves an invoice the "status" property for that invoice should be updated to "Approved"
5. When an invoice is submitted via the API from user story #1, it should populate in the list of displayed invoices without requiring the user to manually refresh the list of invoices.



## My Notes

Story 1 API Back End:
Since the use case is for a simple document, I went with a document db and not a relation database. I used a cosmos db emulator as a server side data store. This is convenient to run locally. You can download from here : https://aka.ms/cosmosdb-emulator

Story 2 Front End:
Ideally I would have used redux for state management on the front end for a more complicated use case. Since this was a simple Invoice approval page, i tried to keep it simple.
