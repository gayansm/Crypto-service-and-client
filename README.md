# Crypto-service-and-client
A service to retrieve crypto currency prices from Cointree.com and a client to display some data.

## Available endpoints
* http://localhost:5000/marketdata/{coin symbol}  - eg. http://localhost:5000/marketdata/btc
* http://localhost:5000/user/preferred
     This accepts post data only. Takes in one string parameter which is the coin symbol. Content of request can be empty.  Request url: http://localhost:5000/User/preferred?symbol={coin symbol}

## How to run
### Starting the API endpoint using command line
- Open a command prompt
- Navigate to CryptoService project directory (..\CryptoService\CryptoService)
- Run the following commands:
    * dotnet restore
    * dotnet run
    This should start the API end points at http://localhost:5000.

### Starting the client that retrieves data from the API
The steps to run the client are similar to the ones for running the API project. The only difference is that the commands should be executed from within the "client" project directory (..\CryptoService\CryptoClient.)
The client should be accessible at http://localhost:5001

## Design aproach
- Keep data separate from controllers.
- Separate storage implementation from data.
- Make pricing data retrieval agnostic from endpoint used.
- Initially designed to only support the three coins described in the second part of the question.
  This was later fixed by including all the coins from the CoinTree endpoint in the data store.
 
 ## Possible improvements
 - Add unit tests!
 - Separate out data storage and tetrieval logic (these are in the same class at the moment)
 - Implement retrieval of all coins from the CoinTree service, in a different way.
   At the moment, this is carried out symchronously at startup.
