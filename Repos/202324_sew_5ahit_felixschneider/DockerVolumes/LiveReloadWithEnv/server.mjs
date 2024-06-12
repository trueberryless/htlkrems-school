import express from "express";

const app = express();

app.get("/", (req, res) => {
    res.send("<h2>Hi there! You hey Felix Schneider</h2>");
});

app.listen(process.env.PORT);
