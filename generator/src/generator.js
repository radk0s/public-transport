import fs from 'fs';
import _ from 'underscore';


const conf = {
    numberOfStops: 125,
    numberOfLines: 40,
    stopsInLine: 0.2,
    numberOfBuses: 20,
    minTraffic: 10,
    maxTraffic: 60,
    busCapacity: 60,
    numberOfIterations: 400,
    poolOfSpecimens: 40,
    mutationChance:20,
    crossoverBernoulli: 0.4,
    crossoverChance: 70,
    output: './input'
};

let stops = _.range(conf.numberOfStops).map((index) => {
    return [index, parseInt(Math.random()*(conf.maxTraffic - conf.minTraffic) + conf.minTraffic)]
});

let routes = _.range(conf.numberOfLines).map((index) => {
    let minSlice = parseInt(Math.random()*conf.numberOfStops/4);
    let lines = stops
        .slice(minSlice, stops.length - parseInt(Math.random()*conf.numberOfStops/4))
        .filter(() => {
        return Math.round(Math.random()- (0.5 - conf.stopsInLine));
    }).map(([route, traffic]) => {
        return route;
    });
    return index +':'+lines
});

let buffer = [];

buffer.push(stops.map((item) => {return item[0]+ ':' + item[1];}).join(','));
buffer.push(``);
buffer.push(conf.numberOfLines);
routes.forEach((route) => {
    buffer.push(route);
});
buffer.push(``);
buffer.push(`busCapacity=${conf.busCapacity}`);
buffer.push(`numberOfIterations=${conf.numberOfIterations}`);
buffer.push(`poolOfSpecimens=${conf.poolOfSpecimens}`);
buffer.push(`mutationChance=${conf.mutationChance}`);
buffer.push(`crossoverBernoulli=${conf.crossoverBernoulli}`);
buffer.push(`crossoverChance=${conf. crossoverChance}`);

fs.writeFileSync(conf.output, buffer.join('\n'));