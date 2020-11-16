const express = require('express');

const app = express();

app.use(express.static('./dist/'));

app.get('/*', (req, res) =>
	res.sendFile('index.html', {root: 'dist/'}),
);

// Run the server!
const start = async () => {
	try {
		const PORT = process.env.PORT || 5001;
		app.listen(PORT, () => console.log(`Server is listening on port ${PORT}...`));
	} catch (err) {
		console.log('error', err);
	}
};

start();
