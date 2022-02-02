import React, { Component } from "react";
import { Modal, Button, Row, Col, Form } from "react-bootstrap";

export class AddGrade extends Component {
  constructor(props) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleSubmit(event) {
    event.preventDefault();
    console.log("POST new grade");
    fetch("https://localhost:44368/api/Student/AddGrade", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        StudentId: this.props.studentId,
        Mark: event.target.Mark.value,
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
      });
  }
  render() {
    return (
      <div className="container">
        <Modal {...this.props} size="lg" aria-labelledby="contained-modal-title-vcenter" centered>
          <Modal.Header closeButton>
            <Modal.Title id="contained-modal-title-vcenter">Add grade</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Row>
              <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                  <Form.Group controlId="Grade">
                    <Form.Label>Mark</Form.Label>
                    <Form.Control type="text" name="Mark" required placeholder="5" />
                  </Form.Group>

                  <Form.Group>
                    <Button variant="primary" type="submit">
                      Add grade
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
