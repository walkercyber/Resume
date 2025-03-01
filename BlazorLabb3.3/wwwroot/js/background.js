
document.addEventListener("DOMContentLoaded", function () {
    const canvas = document.createElement("canvas");
    document.body.appendChild(canvas);
    const ctx = canvas.getContext("2d");
    let width, height;
    const nodes = [];

    function resizeCanvas() {
        width = window.innerWidth;
        height = window.innerHeight;
        canvas.width = width;
        canvas.height = height;
    }

    function Node() {
        this.x = Math.random() * width;
        this.y = Math.random() * height;
        this.size = Math.random() * 3 + 2;
        this.speedX = Math.random() * 0.7 - 0.3;
        this.speedY = Math.random() * 0.7 - 0.4;
    }

    Node.prototype.update = function () {
        this.x += this.speedX;
        this.y += this.speedY;

        if (this.x > width || this.x < 0) this.speedX *= -1;
        if (this.y > height || this.y < 0) this.speedY *= -1;
    };

    Node.prototype.draw = function () {
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.size, 0, Math.PI * 2);
        ctx.fillStyle = "rgba(0, 255, 255, 0.8)";
        ctx.shadowBlur = 15;
        ctx.shadowColor = "cyan";
        ctx.fill();
    };

    function connectNodes() {
        ctx.strokeStyle = "rgba(0, 255, 255, 0.3)";
        for (let i = 0; i < nodes.length; i++) {
            for (let j = i + 1; j < nodes.length; j++) {
                let dx = nodes[i].x - nodes[j].x;
                let dy = nodes[i].y - nodes[j].y;
                let distance = Math.sqrt(dx * dx + dy * dy);

                if (distance < 100) {
                    ctx.beginPath();
                    ctx.moveTo(nodes[i].x, nodes[i].y);
                    ctx.lineTo(nodes[j].x, nodes[j].y);
                    ctx.stroke();
                }
            }
        }
    }

    function initNodes() {
        for (let i = 0; i < 50; i++) {
            nodes.push(new Node());
        }
    }

    function animate() {
        ctx.fillStyle = "black";
        ctx.fillRect(0, 0, width, height);
        nodes.forEach((node) => {
            node.update();
            node.draw();
        });
        connectNodes();
        requestAnimationFrame(animate);
    }

    resizeCanvas();
    initNodes();
    animate();
    window.addEventListener("resize", resizeCanvas);
});
