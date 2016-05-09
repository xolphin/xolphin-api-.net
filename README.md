# Xolphin API wrapper for C&#35;
XolphinApiDotNet is a client library targeting .NET 4.5 and above that provides an easy way to interact with the [Xolphin REST API](https://api.xolphin.com/docs/v1#/).

## About Xolphin
[Xolphin](https://www.xolphin.nl/) is the largest supplier of [SSL Certificates](https://www.sslcertificaten.nl) and [Digital Signatures](https://www.digitalehandtekeningen.nl) in the Netherlands. Xolphin has
a professional team providing reliable support and rapid issuance of SSL Certificates at an affordable price from industry leading brands such as Comodo, GeoTrust, GlobalSign, Thawte and Symantec.

## Library installation
There are 2 ways to use XolphinApiDotNet:
- Install-package XolphinApiDotNet (via Nuget)
- Download source and compile

## Usage
### Client initialization
```csharp
var client = new Client("<username>", "<password>");
```
### Calling conventions
Most of the Requests classes have ability to assign the additional parameters of the request with 2 ways:
```csharp
var reissue = new XolphinApiDotNet.Requests.Reissue(<csr_string>, DCVType.Email);
// 1. Fluent style
reissue.SetApproverEmail("email@domain.com");
// 2. Property assignment
reissue.ApproverEmail = "email@domain.com";
```

### Request operations
#### Getting list of requests
```csharp
// GET /requests
var requests = client.Request.All();
foreach (var request in requests)
{
    Console.WriteLine(request.Id);
}
```
#### Order certificate
```csharp
// POST /requests
var products = client.Support.Products();
if (products.Any())
{
    var productId = products.First().Id;
    // request certificate for 1 year
    var requestsRequest = new XolphinApiDotNet.Requests.Request(productId, 1, <csr_string>, DCVType.Email)
        .SetApproverFirstName("<first_name>")
        .SetApproverLastName("<last_name>")
        .SetApproverPhone("+12345678901")
        .SetZipcode("123456")
        .SetСity("<city>")
        .SetCompany("<company>")
        .SetApproverEmail("<email>")
        .AddSubjectAlternativeName("test1.domain.com")
        .AddSubjectAlternativeName("test2.domain.com")
        .AddSubjectAlternativeName("test3.domain.com")
        .AddDcv(new RequestDCV("test1.domain.com", DCVType.Email, "email1@domain.com"))
        .AddDcv(new RequestDCV("test2.domain.com", DCVType.Email, "email2@domain.com"));

    var responsesRequest = client.Request.Send(requestsRequest);
    Console.WriteLine(responsesRequest.Id);
}
```
#### Getting single request
```csharp
// GET /requests/{id}
var responseRequest = client.Request.Get(1234);
Console.WriteLine(responseRequest.Id);
```
#### Upload new request document
```csharp
// POST /requests/{id}/upload-document
var uploadResponse = client.Request.Upload(1234, new UploadDocument("<file_name>", File.ReadAllBytes("document.pdf")).SetDescription("<description>"));
Console.WriteLine(uploadResponse.Message);
```
#### Retry DCV
```csharp
// POST /requests/{id}/retry-dcv
var retryDcvResponse = client.Request.RetryDCV(1234, new DCV("test.domain.com", DCVType.Email, "email@domain.com"));
Console.WriteLine(retryDcvResponse.Message);
```
#### Send Subscriber Agreement
```csharp
// POST /requests/{id}/sa
var subscribe = client.Request.Subscribe(1234, "email@domain.com");
Console.WriteLine(subscribe.Message);
```
#### Schedule validation call
```csharp
// POST /requests/{id}/schedule-validation-call
var scheduleValidationCallResponse = client.Request.ScheduleValidationCall(1234, DateTime.Now);
Console.WriteLine(scheduleValidationCallResponse.Message);
```
### Certificate operations
#### Getting list of certificates
```csharp
// GET /certificates
var certificates = client.Certificate.All();
foreach (var certificate in certificates)
{
    Console.WriteLine(certificate.Id);
}
```
#### Getting single certificate
```csharp
// GET /certificates/{id}
var certificate = client.Certificate.Get(1234);
Console.WriteLine(certificate.Id);
```
#### Download certificate
```csharp
// GET /certificates/{id}/download
var downloadResult = client.Certificate.Download(1234);
```
#### Reissue certificate
```csharp
// POST /certificates/{id}/reissue
var reissue = new XolphinApiDotNet.Requests.Reissue(<csr_string>, DCVType.Email);
var responsesRequest = client.Certificate.Reissue(1234, reissue);
Console.WriteLine(responsesReissue.Id);
```
#### Renew certificate
```csharp
// POST /certificates/{id}/renew
var products = client.Support.Products();
var productId = products.First().Id;
// renew certificate for 1 year
var renew = new XolphinApiDotNet.Requests.Renew(productId, 1, <csr_string>, DCVType.Email);
var responsesRequest = client.Certificate.Renew(1234, renew);
Console.WriteLine(responsesRequest.Id);
```
#### Cancel certificate
```csharp
// POST /certificates/{id}/cancel
var cancelSettings = new XolphinApiDotNet.Requests.CancelSettings("cancellation reason");
var responsesBase = client.Certificate.Cancel(1234, cancelSettings);
```
### Supporting operations
#### Getting list of approver e-mail addresses
```csharp
// GET /approver-email-addresses
var emailAddresses = client.Support.ApproverEmailAddresses("domain.com");
foreach (var emailAddress in emailAddresses)
{
    Console.WriteLine(emailAddress);
}
```
#### Decode CSR
```csharp
// POST /decode-csr
var csr = client.Support.DecodeCSR(<csr_string>);
Console.WriteLine(csr.Type);
```
#### Getting list of  products
```csharp
// GET /products
var products = client.Support.Products();
foreach (var product in products)
{
    Console.WriteLine(product.Id);
}
```
#### Getting single product
```csharp
// GET /products/{id}
var product = client.Support.Product(1234);
Console.WriteLine(product.Name);
```
