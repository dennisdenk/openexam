<script setup>
    import { VueSignalR } from '@dreamonkey/vue-signalr';
    import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
    const exam = await useFetch('/api/Exam')

    const connected = ref(false);
    
    var connection = new HubConnectionBuilder()
        .withUrl('https://localhost:5001/api/submissionHub')
        .build();

    onMounted(() => {
        connectToHub();
        /* connection = new HubConnectionBuilder()
        .withUrl('https://localhost:5001/api/submissionHub')
        .build().start();

        while(connection.state == "Disconnected") {
            console.log("Waiting for connection")
            connection.start();
        } */

        // connection.invoke('SendMessage', { message: 'Hello World' });
        /* connection.start().then(() => {
            console.log("Connected")
        }) */
    })

    async function connectToHub() {
      // const token =
      /** const options: IHttpConnectionOptions = {
        accessTokenFactory: () => `${localStorage.getItem('access_token')}`,
      }; **/
      connection = new HubConnectionBuilder()
        .withUrl('https://localhost:5001/api/submissionHub') // , options
        .configureLogging(LogLevel.Information)
        .build();

      connection.onreconnecting((x) => {
        // console.log(x.message);
        console.log('Reconnecting');
        this.connected = false;
      });

      connection.onreconnected((x) => {
        console.log(x);
        this.connected = true;
      });

      // const { status } = this;

      

      connection.on('ReceiveSubmission', (data) => {
        console.log("RECEIVED")
        console.log(data);
        // this.dispatchEinsatz(data);
      });

      connection.onclose(start);

      // Start the connection.
      start();
    }
    async function start() {
        if(connection.state == "Disconnected") {
            connected.value = false;
            console.log("Waiting for connection")
            try {
                await connection.start();
                console.log('SignalR Connected.');
                connected.value = true;
                // status.message = 'Connected';
                // this.reconnecting = false;
            } catch (err) {
                console.log(err);
                // this.reconnecting = true;
                // status.message = 'Disconnected';
                console.log(connection.state);
                connected.value = connection.state == "Connected" ? true : false;
                setTimeout(start, 5000);
            }
        } else {
            console.log("Already connected")
        }

    }

    async function sendMessage() {
        while(connection.state == "Disconnected") {
            connected.value = false;
            console.log("Waiting for connection")
            start();
            connected.value = connection.state == "Connected" ? true : false;
        }
        await connection.invoke('SendMessage', "asdfasdf");
    }

</script>


<template>
    <div>
        <h2>
        Prüfung XYZ -- Ihre Abgabe
        </h2>
        <div>
        {{connected}}
        </div>
        <div>
            <button @click="sendMessage">Senden</button>
        </div>
    </div>
</template>