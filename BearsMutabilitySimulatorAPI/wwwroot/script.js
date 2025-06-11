let habitats;

let webworkerCode = `
        async function getBearsFromApi() {
            const url = "http://localhost:5274/bears";
            const response = await fetch(url);
            return await response.json();
        }
        async function startWorker(){
            while (true) {
                const points = await getBearsFromApi();
                postMessage(points);
                await new Promise(resolve => setTimeout(resolve, 10));
            }
        }
        onmessage = function() {
            startWorker();
        };
    `;

async function init() {
    habitats = await getHabitatsFromApi();
    const coordinateSpace = await getCoordinateSpaceFromApi();
    const canvas = document.getElementById('myCanvas');
    canvas.width = coordinateSpace.width;
    canvas.height = coordinateSpace.height;
    initWebWorker(webworkerCode);
}
async function initWebWorker(webworkerCode) {
    const blob = new Blob([webworkerCode], {type: 'application/javascript'});
    const worker =  new Worker(URL.createObjectURL(blob));
    worker.onmessage = function(e) {
        updateView(e.data);
    };
    worker.postMessage(0);
}
function updateView(points) {
    const canvas = document.getElementById('myCanvas');
    const ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    if (habitats) {
        habitats.forEach(habitat => {
            ctx.beginPath();
            ctx.fillStyle = `rgb(${habitat.color[2]}, ${habitat.color[1]}, ${habitat.color[0]})`;
            ctx.fillRect(habitat.topLeft[0], habitat.topLeft[1], habitat.length, habitat.length);
            ctx.closePath();
        });
    }
    if (points) {
        points.forEach(point => {
            ctx.beginPath();
            ctx.arc(point.position[0], point.position[1], 3, 0, Math.PI * 2);
            ctx.fillStyle = `rgb(${point.color[2]}, ${point.color[1]}, ${point.color[0]})`;
            ctx.fill();
            ctx.closePath();
        });
    }
}