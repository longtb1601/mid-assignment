import React, { useState, useEffect } from "react";
import axios from "axios";
import { Formik } from "formik";
import { Form, Button, Row, Col } from "react-bootstrap";

const initialValues = { name: "", categoryId: "" };

const validateValues = (values) => {
    const errors = {};
    if (!values.name) {
        errors.name = "Title of book is required";
    }

    if (!(values.categoryId > 0)) {
        errors.categoryId = "You must choose category";
    }
   
    return errors;
};

const BookCreatePage = () => {
    const onSubmit = (values, { setSubmitting }) => {
        axios.post("https://localhost:5001/api/Book", {
            Name: values.name,
            CategoryId: values.categoryId,
        })
            .then((response) => {
                setSubmitting(false);
                console.log(response);
            });
    };

    const [categories, setCategories] = useState([]);

    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        axios.get('https://localhost:5001/api/Category').then(response => {
            setIsLoading(false);
            setCategories(response.data);
        })
    }, []);

    if (isLoading) return <h1>Loading...</h1>

    return (
        <div className="login-form container">
            <div className="text-center">
                <h3>Create new book</h3>
            </div>
            <Formik
                initialValues={initialValues}
                validate={validateValues}
                onSubmit={onSubmit}
            >
                {({
                    handleSubmit,
                    handleChange,
                    handleBlur,
                    values,
                    touched,
                    isValid,
                    errors,
                    /* and other goodies */
                }) => (
                    <Form noValidate onSubmit={handleSubmit}>
                        <Row className="text-center">
                            <Col md={4}></Col>
                            <Col md={4}>
                                <Form.Group controlId="validationFormik102" className="mb-3">
                                    <Form.Control
                                        placeholder="Title of book"
                                        type="text"
                                        name="name"
                                        value={values.name}
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        isInvalid={touched.name && errors.name}
                                        isValid={touched.name && !errors.name}
                                    />
                                    <Form.Control.Feedback type="valid">
                                        Look good
                                    </Form.Control.Feedback>
                                    <Form.Control.Feedback type="invalid" className="d-block">
                                        {errors.name}
                                    </Form.Control.Feedback>
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="formBasicPassword">
                                    <Form.Select aria-label="" name="categoryId" 
                                        onChange={handleChange}
                                        onBlur={handleBlur} 
                                        isInvalid={touched.categoryId && errors.name}
                                        isValid={touched.categoryId && !errors.name}>
                                        <option>Choose category</option>
                                        {categories.map(
                                            category => (
                                                <option value={category.id}>{category.name}</option>
                                            )
                                        )}
                                    </Form.Select>
                                    <Form.Control.Feedback type="valid">
                                        Look good
                                    </Form.Control.Feedback>
                                    <Form.Control.Feedback type="invalid" className="d-block">
                                        {errors.categoryId}
                                    </Form.Control.Feedback>
                                </Form.Group>

                                <Button variant="primary" type="submit">
                                    Submit
                                </Button>
                            </Col>
                        </Row>
                    </Form>
                )}
            </Formik>
        </div>
    );
};

export default BookCreatePage;
