import express from "express";

import connectToDatabase from "./helpers.mjs";

const app = express();

app.get("/all", (req, res) => {
    res.send(
        "[{'temperture': 21,'humidity': 42,'timestamp': '2023-12-09T16:48:43.202906448+01:00'}]"
    );
});

await connectToDatabase();

app.listen(3000);
