import React from "react";
import Header from '../Header.js';
import Footer from '../Footer.js';

function Lokacija(){
    return(
        <div className="glavnidivg">
            <Header></Header>
            <h1>Dodaj lokaciju preko google maps</h1>
            <h1>📍Bulevar vožda Karađorđa 59, TOPOLA</h1>
            <Footer></Footer>
        </div>
    )
}

export default Lokacija;