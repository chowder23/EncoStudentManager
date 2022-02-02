import React, { Component } from "react";
import { Modal, Button, Row, Col, Form } from "react-bootstrap";

export class AddStudent extends Component {
  constructor(props) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleSubmit(event) {
    event.preventDefault();
    fetch("https://localhost:44368/api/Student", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        Name: event.target.Name.value,
        Year: event.target.SchoolYear.value,
        DateOfBirth: event.target.DateOfBirth.value,
        Phonenumber: event.target.Phonenumber.value,
      }),
    });
  }
  render() {
    return (
      <div className="container">
        <Modal {...this.props} size="lg" aria-labelledby="contained-modal-title-vcenter" centered>
          <Modal.Header closeButton>
            <Modal.Title id="contained-modal-title-vcenter">Add Student</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Row>
              <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                  <Form.Group controlId="Student">
                    <Form.Label>Student name</Form.Label>
                    <Form.Control type="text" name="Name" required placeholder="Example Mark" />
                    <Form.Label>School year</Form.Label>
                    <Form.Control type="text" name="SchoolYear" required placeholder="YYYY" />
                    <Form.Label>Date of birth</Form.Label>
                    <Form.Control type="text" name="DateOfBirth" required placeholder="YYYY.MM.DD" />
                    <Form.Label>Phonenumber</Form.Label>
                    <Form.Control type="text" name="Phonenumber" required placeholder="+36*******" />
                  </Form.Group>

                  <Form.Group>
                    <Button variant="primary" type="submit">
                      Add Student
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
