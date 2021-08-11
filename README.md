# IPAPI
API for consolidating several IP Services from different API's into one.
Simple start of an API bringing together services initially for GeoIP, RDAP, Reverse DNS, and Ping into one API.

This was my first time using Swagger web api and also my first time doing anything with docker. Docker from my perspective was easy. I just had to go through some install and now when I compile and run it just works, but swagger was new and interesting to figure out. I think I have a lot to learn with swagger and it's intricacies, but it was surprisingly easy to get started with it.


Some things I would wnat to work on next include:
1. Setup an Interface or abstraction for services. 
    1. These files are mostly the same and to make it easier to extend an interface could go a long way
2. Figure out Swagger/webapi a bit more.
    1. API path is not optimal (i.e. {getGeo}/{getRDAP}
    2. parameters are not truly optional they just have a default
        a. Maybe this is solved by making them like query parameters (i.e. ?getGeo=true or ?getGeo= instead of just {getGeo}
3. api.viewdns improvements
    1. so far they are all very similar so it would be nice to maybe use an enum for request type and consolodate them into one service
    2. My api key is only a free one with limited uses so it will be necessary to have users suply their own api key or some other solution
