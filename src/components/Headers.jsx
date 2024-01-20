import React from "react";
import { Link } from "react-router-dom";

const Headers = () => {
  return (
    <>
      <nav class="navbar navbar-expand-lg navbar-light bg-dark">
        <a class="navbar-brand" href="#">
          Navbar
        </a>
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarNavDropdown"
          aria-controls="navbarNavDropdown"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavDropdown">
          <ul class="navbar-nav" style={{color:"white"}}>
            <li class="nav-item active">
              <Link to="/dashboard" class="nav-link" href="#" style={{color:"white"}}>
                Dashboard <span class="sr-only">(current)</span>
              </Link>
            </li>
            <li class="nav-item">
             
              <Link to="/addemployee" class="nav-link" href="#" style={{color:"white"}}>
                Add Employee
              </Link>
            </li>
            <li class="nav-item">
            <Link to="/listemployee" class="nav-link" href="#" style={{color:"white"}}>
                List Employee
              </Link>
            </li>

           
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                href="#"
                id="navbarDropdownMenuLink"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
                style={{color:"white"}}
              >
                Dropdown link
              </a>
              <div
                class="dropdown-menu"
                aria-labelledby="navbarDropdownMenuLink"
              >
                <Link to="/dashboard" class="dropdown-item" href="#">
                Dashboard
                </Link>
                <Link to="/addemployee"  class="dropdown-item" href="#">
                Add Employee
                </Link>
                <Link to="/listemployee"  class="dropdown-item" href="#">
                List Employee
                </Link>
              </div>
            </li>
          </ul>
        </div>
      </nav>     
    </>
   
  );
};

export default Headers;
