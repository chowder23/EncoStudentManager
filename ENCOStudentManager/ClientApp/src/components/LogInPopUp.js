import React, { Component } from "react";
import { Modal, Button, Row, Col, Form } from "react-bootstrap";

export class LogInPopUp extends Component {
  constructor(props) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleSubmit(event) {
    event.preventDefault();
    fetch("https://localhost:44368/api/Identity/LogIn", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        username: event.target.Username.value,
        password: event.target.Password.value,
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        if (data) {
          this.props.onHide();
        }
      });
  }
  render() {
    return (
      <div className="container">
        <Modal {...this.props} size="lg" aria-labelledby="contained-modal-title-vcenter" centered>
          <Modal.Header closeButton>
            <Modal.Title id="contained-modal-title-vcenter">Log in</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Row>
              <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                  <Form.Group controlId="LogIn">
                    <Form.Label>Username</Form.Label>
                    <Form.Control type="text" name="Username" required placeholder="UserName" />
                  </Form.Group>
                  <Form.Group controlId="Grade">
                    <Form.Label>Password</Form.Label>
                    <Form.Control type="password" name="Password" required placeholder="*********" />
                  </Form.Group>

                  <Form.Group>
                    <Button variant="primary" type="submit">
                      Login
                    </Button>
                  </Form.Group>
                </Form>
              </Col>
            </Row>
          </Modal.Body>

          <Modal.Footer>
            <Button variant="danger" onClick={this.props.onHide}>
              Close
            </Button>
          </Modal.Footer>
        </Modal>
      </div>
    );
  }
}
