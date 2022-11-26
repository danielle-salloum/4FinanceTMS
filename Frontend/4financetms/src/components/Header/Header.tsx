import "./Header.css";
import React from "react";
//Import of logo
import Logo from "../../assets/4Finance-logo.png";
function Header() {
  return (
    <div className="header-container">
      <img className="header-logo" src={Logo} alt="4Finance Logo" />
      <nav>
        <ul className="menu-ul">
          <li className="menu_item">Teachers Management</li>
          <li className="menu_item">Students Management</li>
          <li className="menu_item">Courses Management</li>
        </ul>
      </nav>
    </div>
  );
}

export default Header;
