import React, { Component } from "react";
import { NavLink } from "react-router-dom";
import { Navbar, Nav } from "react-bootstrap";
import { Button, ButtonToolbar } from "react-bootstrap";
import { LogInPopUp } from "./LogInPopUp";

export class Navigation extends Component {
  constructor(props) {
    super(props);
    this.state = { loginShow: false };
  }

  logOut() {
    fetch("https://localhost:44368/api/Identity/LogOut", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
    });
  }
  render() {
    let loginClose = () => this.setState({ loginShow: false });
    return (
      <Navbar bg="dark" expand="lg">
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav>
            <NavLink className="d-inline p-2 bg-dark text-white" to="/">
              Students
            </NavLink>
            <NavLink className="d-inline p-2 bg-dark text-white" to="/statistics">
              Statistics
            </NavLink>
            <Button variant="primary" onClick={() => this.setState({ loginShow: true })}>
              Login
            </Button>
            <LogInPopUp show={this.state.loginShow} onHide={loginClose} />
            <Button variant="primary" onClick={this.logOut}>
              Log out
            </Button>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
