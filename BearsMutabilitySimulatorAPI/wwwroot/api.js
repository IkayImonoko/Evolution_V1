async function getHabitatsFromApi() {
    const url = "/habitats";
    const response = await fetch(url);
    return await response.json();
}
async function getCoordinateSpaceFromApi() {
    const url = "/coordinatespace";
    const response = await fetch(url);
    return await response.json();
}

async function startSimulationTroughApi() {
    const url = "/start";
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

