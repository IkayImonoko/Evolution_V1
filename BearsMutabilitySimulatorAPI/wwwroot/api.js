async function getHabitatsFromApi() {
    const url = "http://localhost:5274/habitats";
    const response = await fetch(url);
    return await response.json();
}
async function getCoordinateSpaceFromApi() {
    const url = "http://localhost:5274/coordinatespace";
    const response = await fetch(url);
    return await response.json();
}

async function startSimulationTroughApi() {
    const url = "http://localhost:5274/start";
    const response = await fetch(url, {
        method: "POST",
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        }
    });
}

async function stopSimulationTroughApi(){
    const url = "/stop";
    const response = await fetch(url, {
        method: "POST",
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        }
    });
}


