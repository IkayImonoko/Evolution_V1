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

