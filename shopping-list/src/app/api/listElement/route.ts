

type Test = {
    newItem: string
}

export async function POST(request: Request) {
    const data: Test = await request.json()
    const result = data.newItem;

    const DB_USER = "hannemarenh"
    const DB_PASS = "jajaMongo"
    const MONGODB_URI = "mongodb+srv://" + DB_USER + ":" + DB_PASS + "@shopping-list.p0gpfxf.mongodb.net/?retryWrites=true&w=majority";

    const { MongoClient, ServerApiVersion } = require('mongodb');
    const uri = "mongodb+srv://hannemarenh:jajaMongo@shopping-list.p0gpfxf.mongodb.net/?retryWrites=true&w=majority";
    // Create a MongoClient with a MongoClientOptions object to set the Stable API version
    const client = new MongoClient(uri, {
        serverApi: {
            version: ServerApiVersion.v1,
            strict: true,
            deprecationErrors: true,
        }
    });
    async function run() {
        try {
            // Connect the client to the server	(optional starting in v4.7)
            await client.connect();
            // Send a ping to confirm a successful connection
            await client.db("shopping-list").command({ ping: 1 });
            console.log("Pinged your deployment. You successfully connected to MongoDB!");
            await client.db("shopping-list").collection("items").insertOne({ item: result })
        } finally {
            // Ensures that the client will close when you finish/error
            await client.close();
        }
    }
    run().catch(console.dir);


    return new Response(JSON.stringify({ 'newItem': result }), { status: 201 })
}

export async function GET() {
    const { MongoClient, ServerApiVersion } = require('mongodb');
    const uri = "mongodb+srv://hannemarenh:jajaMongo@shopping-list.p0gpfxf.mongodb.net/?retryWrites=true&w=majority";
    // Create a MongoClient with a MongoClientOptions object to set the Stable API version
    const client = new MongoClient(uri, {
        serverApi: {
            version: ServerApiVersion.v1,
            strict: true,
            deprecationErrors: true,
        }
    });
    // Connect the client to the server	(optional starting in v4.7)
    await client.connect();
    // Send a ping to confirm a successful connection
    await client.db("shopping-list").command({ ping: 1 });
    console.log("Pinged your deployment. You successfully connected to MongoDB!");


    const collection = await client.db("shopping-list")

        .collection("items")

        .find({})

        .sort({})

        .limit(1000)
        .toArray()


    // Ensures that the client will close when you finish/error
    await client.close();


    return new Response(JSON.stringify({ 'collection': collection }), { status: 201 })
}


