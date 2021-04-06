# Crypto-service-and-client
A service to retrieve crypto currency prices from Cointree.com and a client to display some data.


## Design aproach
-Keep data separate from controllers.
-Separate storage implementation from data.
-Make pricing data retrieval agnostic from endpoint used.
-Initially designed to only support the three coins described in the second part of the question.
 This was later fixed by including all the coins from the CoinTree endpoint in the data store.
 
 ## Possible improvements
 - Add unit tests!
 - Separate out data storage and tetrieval logic (these are in the same class at the moment)
 - Implement retrieval of all coins from the CoinTree service, in a different way.
   At the moment, this is carried out symchronously at startup.
