Single page basic Online Store app; React and Redux with ASP.NET CORE 2.0 Web Api.

# Web API
- RabbitMQ,
- SignalR
- Generic Repostory Pattern (Entity Framework Reository and Dapper Repository)
- Asp.Net Core 2.1.4
- Entity Framework Core 2.1.3
- Dapper
- JwtBearer Token Authentication
- Dependency Injection
- EPPlus Excel Download

# React Component
  - redux-from
  - material UI
  - axios
  - react-router
  - react-block-ui
  - react-pager
  - bootbox

# Prerequisites
  
  - .NetFramework 4.7 (Asp.Net Core 2.1.4) (VS 2015/2017)  
  - node.js 8 >

### Database and RabbitMQ

* Download [RabbitMQ](https://www.rabbitmq.com/download.html) Install your computer
* Open SQL Server Management Studio > File > Open > File  select Store.sql and execute
* Change OnlineStore.API > appsettings.json file connection string Data Source your server name

### Installation Node Module

Open command prompt

```sh
cd OnlineStoreReact folder location
npm install 
npm start

cd OnlineStoreCoreWebApi/OnlineStore.API
dotnet run

cd OnlineStoreCoreWebApi/OnlineStore.MQService
dotnet run

open yor browser go to the product detail page(localhost:3000/web/productdetail/:id)
and open another tab on your browser and theen go to admin product update page (localhost:3000/admin)
and change product stock quantity


```
### Web Site
- http&#58;//localhost:3000/web

### Admin Panel
- http&#58;//localhost:3000/admin
