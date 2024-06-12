---
marp: true
theme: uncover
class:
    - invert
paginate: true
---

# <!--fit-->Messomat 7K

mit Rust und Angular

---

<!--
_footer: 'Messomat 7K - Clemens & Felix'
-->

![bg right:33%](./api.png)

## Backend

-   Rust Nightly
-   Tokio Async Runtime
-   Tokio Serial (Serialport Library)
-   parallel Request Handling
-   Protocol fully mapped in Rust

---

![bg](./serial_port.png)

---

<!--
_footer: 'Messomat 7K - Clemens & Felix'
-->

## Frontend

-   Angular (JS Framework)
-   ruft API auf
-   nutzt Angular Material (UI-Library wie MudBlazor)
-   nutzt NgxCharts für Diagramme (Line & Bar Charts)

---

![bg](./overview.png)

---

![bg](./fan.png)
![bg](./settings.png)

---

<!--
_footer: 'Messomat 7K - Clemens & Felix'
-->

<style>
    @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@900&display=swap');
    h1 {
        font-family: 'Poppins';
    }
</style>

# <!--fit-->THX
